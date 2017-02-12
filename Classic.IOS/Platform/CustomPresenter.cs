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
                this.MainNC.SetNavigationBarHidden(true, false);
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
            this.ShowIphone(view);
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
        /// Crea un navigationController.
        /// Se implementa para poder llamar a esta funcionalidad desde fuera de la clase.
        /// </summary>
        /// <returns>The navigation controller from out.</returns>
        /// <param name="viewController">View controller.</param>
        public UINavigationController CreateNavigationControllerFromOut(UIViewController viewController)
        {
            return this.CreateNavigationController(viewController);
        }

        /// <summary>
        /// Se llama al iniciar 
        /// </summary>
        /// <param name="viewController">View controller.</param>
        protected override void ShowFirstView(UIViewController viewController)
        {
            base.ShowFirstView(viewController);
        }

        /// <summary>
        /// Creates the navigation controller.
        /// </summary>
        /// <returns>The navigation controller.</returns>
        /// <param name="viewController">View controller.</param>
        protected override UINavigationController CreateNavigationController(UIViewController viewController)
        {
            // Cambia el color de todas las barras de estado de la aplicación.
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGBA(185, 200, 0, 1);
            return base.CreateNavigationController(viewController);
        }

        /// <summary>
        /// Navegación en iPhone
        /// </summary>
        /// <param name="view">View.</param>
        private void ShowIphone(MvvmCross.iOS.Views.IMvxIosView view)
        {
            this.mainNC.PushViewController((UIKit.UIViewController)view, true);


            base.Show(view);
        }
    }
}