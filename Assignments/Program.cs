using Assignments;
using NUnit.Framework;

//AmazonHP amazonHP = new AmazonHP(); //creating object for AmazonHP class

//try
//{
//    amazonHP.InitializeChromeDriver(); // calling InitializeChromeDriver function
//    amazonHP.TitleTest();            // calling TitleTest Function
//    amazonHP.OrganisationType();     //calling OrganisationType function
//}
//catch(AssertionException)
//{
//    Console.WriteLine("Test failed");
//}
//amazonHP.Destruct(); // calling Destruct function for closing the tab

YahooDiwali yahooDiwali = new YahooDiwali(); // creating an object for YahooDiwali class
try
{
    yahooDiwali.InitializeChromeDriver(); //calling InitializeChromeDriver function

    yahooDiwali.GStest();//calling google search funcion

}
catch(AssertionException)
{
    Console.WriteLine("Test failed");

}yahooDiwali.destruct();// calling function for closing the tab