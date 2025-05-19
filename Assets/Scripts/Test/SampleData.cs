using System;

[Serializable]
public class SampleData
{
    public string name;
    public Address address;
    public Book[] books;
}

[Serializable]
public class Address
{
    public int unit;
    public string road;
    public string city;
}

[Serializable]
public class Book
{
    public string bookName;
    public bool isDigital;
    public string author;
}