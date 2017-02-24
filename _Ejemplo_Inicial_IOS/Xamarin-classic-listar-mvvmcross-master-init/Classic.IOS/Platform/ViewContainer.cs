//-----------------------------------------------------------------------
// <copyright company="Bankia">
//     Copyright (c) Bankia. Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------
namespace Bankia.IOS
{
    using System;
    using System.Collections.Generic;
    using MvvmCross.Core.ViewModels;
    using MvvmCross.iOS.Views;
    using UIKit;

    /// <summary>
    /// Necesario para poder realizar la navegación personalizada para iOS.
    /// </summary>
    public class ViewContainer : IMvxIosViewsContainer
    {
        private MvxViewModelRequest request;

        /// <summary>
        /// Obtiene el tipo de la vista..
        /// </summary>
        /// <value>The current request.</value>
        public MvvmCross.Core.ViewModels.MvxViewModelRequest CurrentRequest
        {
            get
            {
                return this.request;
            }
        }

        /// <summary>
        /// Crea la vista de iPhone o iPad, según el dispositivo en el que se ejecute la App.
        /// Cada View de la App se implementa en un fichero .storyboard, con el mismo nombre que su viewModel,
        /// sin la palabra "Model" y con el mismo "Storyboard ID" que el nombre del fichero.
        /// </summary>
        /// <returns>La vista (cargada desde un Storyboard) iPhone/iPad</returns>
        /// <param name="request">Indica el tipo de vista que se desea cargar.</param>
        public IMvxIosView CreateView(MvvmCross.Core.ViewModels.MvxViewModelRequest request)
        {
            this.request = request;

            string storyBoardViewName = this.request.ViewModelType.Name.Replace("Model", string.Empty);

            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                storyBoardViewName += "_iPad";
            }

            var viewToLoad = (IMvxIosView)UIStoryboard.FromName(storyBoardViewName, null).InstantiateViewController(storyBoardViewName);

            return viewToLoad;
        }

        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="viewModel">View model.</param>
        public IMvxIosView CreateView(MvvmCross.Core.ViewModels.IMvxViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds all.
        /// </summary>
        /// <param name="viewModelViewLookup">View model view lookup.</param>
        public void AddAll(System.Collections.Generic.IDictionary<Type, Type> viewModelViewLookup)
        {
        }

        /// <summary>
        /// Add the specified viewModelType and viewType.
        /// </summary>
        /// <param name="viewModelType">View model type.</param>
        /// <param name="viewType">View type.</param>
        public void Add(Type viewModelType, Type viewType)
        {
        }

        /// <summary>
        /// Add this instance.
        /// </summary>
        /// <typeparam name="TViewModel">The 1st type parameter.</typeparam>
        /// <typeparam name="TView">The 2nd type parameter.</typeparam>
        public void Add<TViewModel, TView>() where TViewModel : MvvmCross.Core.ViewModels.IMvxViewModel where TView : MvvmCross.Core.Views.IMvxView
        {
        }

        /// <summary>
        /// Adds the secondary.
        /// </summary>
        /// <param name="finder">Finder finder.</param>
        public void AddSecondary(MvvmCross.Core.Views.IMvxViewFinder finder)
        {
        }

        /// <summary>
        /// Sets the last resort.
        /// </summary>
        /// <param name="finder">Finder finder.</param>
        public void SetLastResort(MvvmCross.Core.Views.IMvxViewFinder finder)
        {
        }

        /// <summary>
        /// Gets the type of the view.
        /// </summary>
        /// <returns>The view type.</returns>
        /// <param name="viewModelType">View model type.</param>
        public Type GetViewType(Type viewModelType)
        {
            return null;
        }
    }
}