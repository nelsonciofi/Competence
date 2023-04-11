# CompetenceMonth  
CompetenceMonth is a C# struct that standardizes month competence representation and conversion. This struct provides an effective solution for handling month competence representation and conversion in C# code.

## Usage
To use CompetenceMonth in your project, simply include the CompetenceMonth.cs file in your project and start using it.

Here's an example:

```csharp
CompetenceMonth month = new CompetenceMonth(2022, 3);

// Convert to month count
int monthCount = month.ToMonthCount();

// Convert to DateTime
DateTime dateTime = month.ToDateTime();
```

# Features
CompetenceMonth provides the following features:

- Standardizes month competence representation and conversion
- Constructors allow for the creation of a CompetenceMonth instance using different input formats such as year and month, month count, text, and DateTime
- Conversion methods allow for the conversion of a CompetenceMonth instance to other formats such as month count, DateTime, and text
- Implements IEquatable and IComparable interfaces for equality comparisons and sorting
- Overrides operators for easy conversion between CompetenceMonth and int/string/DateTime types
- Provides extension methods for easy parsing and validation
- Includes database converters and mappers for EF Core and Dapper


## Contribution
Feel free to contribute to the project by submitting issues or pull requests.

## License
This project is licensed under the MIT License.