namespace CurlMini.Properties {
    using System;
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CurlMini.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        internal static byte[] curl {
            get {
                object obj = ResourceManager.GetObject("curl", resourceCulture);
                return ((byte[])(obj));
            }
        }
        internal static System.Drawing.Bitmap Delete {
            get {
                object obj = ResourceManager.GetObject("Delete", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        internal static System.Drawing.Bitmap FullTextBox {
            get {
                object obj = ResourceManager.GetObject("FullTextBox", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        internal static System.Drawing.Bitmap GifExit {
            get {
                object obj = ResourceManager.GetObject("GifExit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        internal static System.Drawing.Bitmap GitHub {
            get {
                object obj = ResourceManager.GetObject("GitHub", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        internal static System.Drawing.Bitmap Insert {
            get {
                object obj = ResourceManager.GetObject("Insert", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        internal static System.Drawing.Bitmap install_crt {
            get {
                object obj = ResourceManager.GetObject("install_crt", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        internal static System.Drawing.Bitmap Recent {
            get {
                object obj = ResourceManager.GetObject("Recent", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}