using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorApp1.Client.Shared.MainLayout;
using MathNet.Numerics.Statistics;

namespace BlazorApp1.Client.Pages
{
     public partial class CounterBase: ComponentBase
    {

 
        [Inject] protected IJSRuntime  JS { get; set; }




        IJSObjectReference modulo;


        protected int currentCount = 0;
        static int currentCountStatic = 0;
        [JSInvokable]
        public async Task IncrementCount()
        {
            var arreglo = new double[] { 1, 2, 3, 4, 5 };
            var max = arreglo.Maximum();
            var min = arreglo.Minimum();
            modulo = await JS.InvokeAsync<IJSObjectReference>("import", "./js/Countert.js");
            await modulo.InvokeVoidAsync("mostrarAlerta",$"El max es {max} y el min es {min}");

            currentCount++;
   
            currentCountStatic++;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");
        }

        protected async Task IncrementCountJavaScript()
        {
            await JS.InvokeVoidAsync("pruebaPuntoNetInstancia",
                DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public static Task<int> ObtenerCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }

    }
}
