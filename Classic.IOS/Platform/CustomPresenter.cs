//-----------------------------------------------------------------------
// <copyright company="Bankia">
//     Copyright (c) Bankia. Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------
using System.Linq;
using MvvmCross.Core.Platform;


namespace Bankia.IOS.SpecificPlatform
{
    using System;
    using System.Collections.Generic;
    using Foundation;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.iOS.Platform;
    using MvvmCross.iOS.Views;
    using MvvmCross.iOS.Views.Presenters;
    using MvvmCross.Platform;
    using MvvmCrossIos;
    using UIKit;

    /// <summary>
    /// Clase para implementar el CustomPresenter de la App de iOS.
    /// </summary>
    public class CustomPresenter : MvxIosViewPresenter
    {
        private UINavigationController mainNC;

        /// <summary>
        /// Se obtiene el navigationController que navega para cada opción del menú.
        /// </summary>
        public UINavigationController MainNC
        {
            get
            {
                return this.mainNC;
            }

            set
            {
                this.mainNC = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bankia.IOS.CustomPresenter"/> class.
        /// </summary>
        /// <param name="applicationDelegate">Application delegate.</param>
        /// <param name="window">Window que contiene todas los elementos de la interfaz de la App</param>
        public CustomPresenter(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
            this.mainNC = new UINavigationController();
        }

        /// <summary>
        /// Obtiene la vista que actualemente está en el top de la pila de vistas.
        /// </summary>
        /// <value>The current top view controller.</value>
        protected override UIViewController CurrentTopViewController
        {
            get
            {
                return base.CurrentTopViewController;
            }
        }

        /// <summary>
        /// Se llama cuando se hace un "pop".
        /// Se encarga de hacer un "Pop" sobre la navegación del Login -> HomeView.
        /// Elimina las referencias a la home y la navegación de los productos.
        /// </summary>
        /// <param name="toClose">Ventana sobre la cual deshacer la navegación.</param>
        public override void Close(IMvxViewModel toClose)
        {
            
        }

        /// <summary>
        /// Metodo de ChangePresentation
        /// </summary>
        /// <param name="hint">Parametro Hint</param>
        public override void ChangePresentation(MvxPresentationHint hint)
        {
            base.ChangePresentation(hint);
        }

        /// <summary>
        /// Oculta ventanas modales.
        /// </summary>
        public override void CloseModalViewController()
        {
            base.CloseModalViewController();
        }

        /// <summary>
        /// Show the specified view.
        /// </summary>
        /// <param name="view">La vista.</param>
        public override void Show(MvvmCross.iOS.Views.IMvxIosView view)
        {
            if(this.mainNC.ViewControllers.Count() == 0)
            {
                UIViewController[] vCs = new UIViewController[1] { (UIKit.UIViewController)view };
                this.MainNC.SetViewControllers(vCs, false);
            }
            else
            { 
                this.mainNC.PushViewController((UIKit.UIViewController)view, true);
            }
        
            base.Show(view);
        }

        /// <summary>
        /// Show the specified request.
        /// </summary>
        /// <param name="request">EL modelo.</param>
        public override void Show(MvxViewModelRequest request)
        {
            base.Show(request);
        }

        /// <summary>
        /// Se llama al iniciar 
        /// </summary>
        /// <param name="viewController">View controller.</param>
        protected override void ShowFirstView(UIViewController viewController)
        {
            base.ShowFirstView(viewController);
        }

    }
}