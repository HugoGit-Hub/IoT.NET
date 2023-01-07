# TP IoT

## Prérequis 

- ASP.NET Core 5
- SDK .net framework 7

## Modifier le tp-iot-main
*Ne pas utiliser en production car bypass le ssl*
> Ajouter la ligne suivante au début des capteurs humidity et temperature :

```
process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
```

> Changer le format des endpoints :
```
https://localhost:5001/api/Humidity
https://localhost:5001/api/Temperature
```

## Commandes
> Se placer dans le projet ../TP/TP.API :
```
dotnet build
dotnet run
```
> Ne pas oublier de changer le token dans appsettings.json :
```
"InfluxDB": {
  "Token": "Your_Token_Goes_Here"
}
```
> Changer égelement le bucket et l'organisation dans les controllers :
```
_service.Write(write =>
{
    var point = PointData.Measurement("my_measures_sensors")
        .Field(valueName, value);

    write.WritePoint(point, "HD", "HD");
});
```
> Lancer les capteurs
