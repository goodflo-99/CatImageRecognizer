﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CatImageRecognizer.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CatImageRecognizer.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;ResourceDictionary xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
        ///                    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;&gt;
        ///    &lt;Canvas x:Key=&quot;appbar_3d_3ds&quot; Width=&quot;76&quot; Height=&quot;76&quot; Clip=&quot;F1 M 0,0L 76,0L 76,76L 0,76L 0,0&quot;&gt;
        ///        &lt;Path Width=&quot;32&quot; Height=&quot;40&quot; Canvas.Left=&quot;23&quot; Canvas.Top=&quot;18&quot; Stretch=&quot;Fill&quot; Fill=&quot;{DynamicResource BlackBrush}&quot; Data=&quot;F1 M 27,18L 23,26L 33,30L 24,38L 33,46L 23,50L 27,58L 45,58L 55,38L 45,18L 27,18 Z &quot;/&gt;
        ///    &lt;/Canvas&gt;
        ///
        ///    &lt;Canvas x:Key=&quot;appb [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string Icons {
            get {
                return ResourceManager.GetString("Icons", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap WelcomeCat {
            get {
                object obj = ResourceManager.GetObject("WelcomeCat", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
