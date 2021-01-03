using CatImageRecognizer.Models;
using CatImageRecognizer.NeuralNetworks;
using Emgu.CV;
using Emgu.CV.Structure;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CatImageRecognizer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public TrainingWindowViewModel TrainingViewModel { get; set; }

        public INeuralNetwork NeuralNetwork;
        public DetectorViewModel DetectorViewModel { get; set; }

        private bool modelNotLoaded = true;
        public bool ModelNotLoaded
        {
            get
            {
                return modelNotLoaded;
            }
            set
            {
                modelNotLoaded = value;
                RaiseProperty("ModelNotLoaded");
            }
        }

        private string statusMessage = "Готово";
        public string StatusMessage
        {
            get
            {
                return statusMessage;
            }
            set
            {
                statusMessage = value;
                RaiseProperty("StatusMessage");
            }
        }

        private bool isSavingNetwork = false;
        public bool IsSavingNetwork
        {
            get
            {
                return isSavingNetwork;
            }
            set
            {
                isSavingNetwork = value;
                RaiseProperty("IsSavingNetwork");
            }
        }

        private bool isLoadingNetwork = false;
        public bool IsLoadingNetwork
        {
            get
            {
                return isLoadingNetwork;
            }
            set
            {
                isLoadingNetwork = value;
                RaiseProperty("IsLoadingNetwork");
            }
        }

        public MainWindowViewModel(INeuralNetwork neuralNetwork)
        {
            NeuralNetwork = neuralNetwork;
            OpenTrainWindowCommand = new RelayCommand(OnClickedTrainWindowButton);
            SaveNeuralNetwork = new RelayCommand(OnSaveNeuralNetwork);
            TrainingViewModel = new TrainingWindowViewModel(ref NeuralNetwork);
            DetectorViewModel = new DetectorViewModel(ref NeuralNetwork, (message) =>
            {
                this.StatusMessage = message;
            });
            LoadNeuralNetwork = new RelayCommand(OnLoadNeuralNetwork);
        }

        public ICommand OpenTrainWindowCommand { get; set; }
        public ICommand SaveNeuralNetwork { get; set; }
        public ICommand LoadNeuralNetwork { get; set; }

        public void OnClickedTrainWindowButton()
        {
            this.ModelNotLoaded = false;
            TrainingViewModel = new TrainingWindowViewModel(ref NeuralNetwork);
            TrainingWindow trainWindow = new TrainingWindow(TrainingViewModel);
            trainWindow.ShowDialog();
        }

        private string GetFileDialogFilter()
        {
            return $"{NeuralNetwork.GetNetworkName()} Model File|*.{NeuralNetwork.GetModelExtension()}";
        }

        public void OnSaveNeuralNetwork()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = GetFileDialogFilter();
            saveDialog.ShowDialog();
            if(saveDialog.FileName == "")
            {
                return;
            }
            Task task = new Task(() =>
            {
                this.IsSavingNetwork = true;
                this.StatusMessage = "Збереження моделі нейронної мережі. Будь ласка, зачекайте...";
                NeuralNetwork.SaveNetwork(saveDialog.FileName);
            });
            task.Start();
            task.ContinueWith((a) =>
            {
                this.IsSavingNetwork = false;
                this.StatusMessage = "Готово";
                this.ModelNotLoaded = false;
                MessageBox.Show("Модель зберігається!", "Збереження закінчено!", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }

        public void OnLoadNeuralNetwork()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = GetFileDialogFilter();
            fileDialog.ShowDialog();
            if (fileDialog.CheckFileExists && fileDialog.FileName != "")
            {
                this.IsLoadingNetwork = true;
                this.StatusMessage = "Завантаження моделі нейронної мережі. Будь ласка, зачекайте...";
                Task task = new Task(() =>
                {
                    try
                    {
                        var localFilePath = fileDialog.FileName;
                        NeuralNetwork.LoadNetworkFromFile(localFilePath);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Помилка файлу нейронної мережі", "Помилка зчитування!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
                task.Start();
                task.ContinueWith((a) =>
                {
                    this.IsLoadingNetwork = false;
                    this.StatusMessage = "Готово";
                    this.ModelNotLoaded = false;
                    MessageBox.Show("Заватаження модулі нейронної мережі. Гарного тестування!", "Завантаження завершено!", MessageBoxButton.OK, MessageBoxImage.Information);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
