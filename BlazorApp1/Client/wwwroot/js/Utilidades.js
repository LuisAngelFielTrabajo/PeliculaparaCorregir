function pruebaPuntoNetStatic() {
    DotNet.invokeMethodAsync("BlazorApp1.Client", "ObtenerCurrentCount")
        .then(resultado => {
            console.log("conteo desde js" + resultado);
        });
}

function pruebaPuntoNetInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");

}