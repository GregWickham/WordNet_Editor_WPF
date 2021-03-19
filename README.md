# WordNet User Interface for WPF

This is a user interface for Wordnet, written on the Windows WPF platform and using a SQL Server database that contains the WordNet data.

Here's [the project site](https://gregwickham.github.io/WordNet_GUI/).

The SQL Server database that supports this application can be found at [this repo](https://github.com/GregWickham/WordNet-MS-SQL).  Much of the editor's functionality is implemented on the server side.

### Setup

The database connection string is built in the ConnectionString property of [WordNetData.cs](https://github.com/GregWickham/WordNet_GUI/blob/master/WordNetLINQ/WordNetData.cs).
