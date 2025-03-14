# Measurements Extensions
## Table of contents
- [Documentation](#documentation)
  - [Measurements](#measurementExtensions)
      - [FromMeters](#measurementExtensionsFromMeters)
      - [ToMeters](#measurementExtensionsToMeters)
      - [FromCelsius](#measurementExtensionsFromCelsius)
      - [ToCelsius](#measurementExtensionsToCelsius)
      - [FromKilograms](#measurementExtensionsFromKilograms)
      - [ToKilograms](#measurementExtensionsToKilograms)
      - [FromMetersSecond](#measurementExtensionsFromMetersSecond)
      - [ToMetersSecond](#measurementExtensionsToMetersSecond)
      - [FromSeconds](#measurementExtensionsFromSeconds)
      - [ToSeconds](#measurementExtensionsToSeconds)

## Documentation <a name="documentation"/>
### Measurements Extensions <a name="measurementExtensions"/>
#### FromMeters <a name="measurementExtensionsFromMeters"/>
Converts a float value from meters to a specific unit of length
#### Declaration
```csharp
float FromMeters(LengthUnitType lengthUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| LengthUnitType | lengthUnitType | The unit of length to convert to |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the distance in the desired unit of length |


#### ToMeters <a name="measurementExtensionsToMeters"/>
Converts a float value from a specific unit of length to meters
#### Declaration
```csharp
float ToMeters(LengthUnitType lengthUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| LengthUnitType | lengthUnitType | The unit of length to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the distance in meters |


#### FromCelsius <a name="measurementExtensionsFromCelsius"/>
Converts a float value from celsius to a specific unit of temperature
#### Declaration
```csharp
float FromCelsius(TemperatureUnitType temperatureUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TemperatureUnitType | temperatureUnitType | The unit of temperature to convert to |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the temperature in the desired unit |


#### ToCelsius <a name="measurementExtensionsToCelsius"/>
Converts a float value from a specific unit of temperature to celsius
#### Declaration
```csharp
float ToCelsius(TemperatureUnitType temperatureUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TemperatureUnitType | temperatureUnitType | The unit of temperature to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the temperature in celsius |


#### FromKilograms <a name="measurementExtensionsFromKilograms"/>
Converts a float value from kilograms to a specific unit of mass
#### Declaration
```csharp
float FromKilograms(MassUnitType massUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| MassUnitType | massUnitType | The unit of mass to convert to |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the mass in the desired unit |


#### ToKilograms <a name="measurementExtensionsToKilograms"/>
Converts a float value from a specific unit of mass to kilograms
#### Declaration
```csharp
float ToKilograms(MassUnitType massUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| MassUnitType | massUnitType | The unit of mass to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the mass in kilograms |


#### FromMetersSecond <a name="measurementExtensionsFromMetersSecond"/>
Converts a float value from meters per second to a specific unit of speed
#### Declaration
```csharp
float FromMetersSecond(SpeedUnitType speedUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| SpeedUnitType | speedUnitType | The unit of speed to convert to |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the speed in the desired unit |


#### ToMetersSecond <a name="measurementExtensionsToMetersSecond"/>
Converts a float value from a specific unit of speed to meters per second
#### Declaration
```csharp
float ToMetersSecond(SpeedUnitType speedUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| SpeedUnitType | speedUnitType | The unit of speed to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the speed in meters per second |


#### FromSeconds <a name="measurementExtensionsFromSeconds"/>
Converts a float value from seconds to a specific unit of time
#### Declaration
```csharp
float FromSeconds(TimeUnitType timeUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TimeUnitType | timeUnitType | The unit of time to convert to |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the time in the desired unit |


#### ToSeconds <a name="measurementExtensionsToSeconds"/>
Converts a float value from a specific unit of time to seconds
#### Declaration
```csharp
float ToSeconds(TimeUnitType timeUnitType);
```
#### Parameters
| Type | Name | Description |
| :--- | :--- | :--- |
| TimeUnitType | timeUnitType | The unit of time to convert from |
#### Returns
| Type | Description |
| :--- | :--- |
| float | Float value representing the time in seconds |