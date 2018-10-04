# Original Objective: Recurly Dates

The Recurly Dates package is an Umbraco data type for creating a recurring list of dates. Choose from Daily, Weekly, Monthly or Yearly. Define on which days the event is to recur.

## Installation

The Recurly Dates package can be installed via the package's page on [our.umbraco.org](http://our.umbraco.org/projects/backoffice-extensions/recurly-dates) or via NuGet. If installing via NuGet, use the following package manager command:

    Install-Package OriginalObjective.RecurlyDates

## Configuration

Setup a new data type and select the OriginalObjective.RecurlyDates within Umbraco's Developer section.

## Usage

When using a property value on a template...

## Contributing

To raise a new bug, create an [issue](https://github.com/originalobjective/recurly-dates/issues) on the Github repository. To fix a bug or add new features or providers, fork the repository and send a [pull request](https://github.com/originalobjective/recurly-dates/pulls) with your changes. Feel free to add ideas to the repository's [issues](https://github.com/originalobjective/recurly-dates/issues) list if you would to discuss anything related to the package.

## Publishing

Remember to include all necessary files within the package.xml file. Run the following script, entering the new version number when prompted to created a published version of the package:

    Build\Release.bat

The release script will amend all assembly versions for the package, build the solution and create the package file. The script will also commit and tag the repository accordingly to reflect the new version.