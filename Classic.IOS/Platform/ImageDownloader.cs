//-----------------------------------------------------------------------
// <copyright company="Bankia">
//     Copyright (c) Bankia. Todos los derechos reservados.
// </copyright>
//-----------------------------------------------------------------------
namespace Bankia.IOS.SpecificPlatform
{
    using Foundation;
    using System;
    using System.Net;
    using UIKit;

    /// <summary>
    /// Clase encargada de la gestión de imágenes a partir de una URL.
    /// </summary>
    public class ImageDownloader
    {
        private WebClient webClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bankia.IOS.SpecificPlatform.ImageDownloader"/> class.
        /// </summary>
        public ImageDownloader()
        {
            this.webClient = new WebClient();
        }

        /// <summary>
        /// Evento que se lanza cuando se recibe una imagen a partir de la URL.
        /// </summary>
        public event EventHandler GetImageEvent;

        /// <summary>
        /// Método encargado de descargar una imagen a partir de una URL.
        /// </summary>
        /// <param name="urlImage">La URL de la imagen a descargar.</param>
        public void DownloadImage(string urlImage)
        {
            // Si no existe una URL o es muy corta.
            if (urlImage == null ||
                urlImage.Length <= "https://".Length)
            {
                // Se envía null como datos, mediante el uso del evento.
                if (this.GetImageEvent != null)
                {
                    this.GetImageEvent(null, null);
                }

                return;
            }

            var url = new Uri(urlImage);

            try
            {
                this.webClient.DownloadDataCompleted += (s, e) =>
                {
                    try
                    {
                        var bytes = e.Result; // get the downloaded data
                        NSData data = NSData.FromArray(bytes);

                        // Se envía la imagen en formato "NSData".
                        if (this.GetImageEvent != null)
                        {
                            UIApplication.SharedApplication.InvokeOnMainThread(() =>
                            {
                                this.GetImageEvent(data, null);
                            });


                        }
                    }
                    catch (Exception)
                    {
                        // Se envía un null, debido a que ha ocurrido un error en la descarga de la imagen.
                        if (this.GetImageEvent != null)
                        {
                            this.GetImageEvent(null, null);
                        }
                    }
                };
            }
            catch (Exception)
            {
                // Se envía un null, debido a que ha ocurrido un error en la descarga de la imagen.
                if (this.GetImageEvent != null)
                {
                    this.GetImageEvent(null, null);
                }
            }

            this.webClient.DownloadDataAsync(url);
        }
    }
}