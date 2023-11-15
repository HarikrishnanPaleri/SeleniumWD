using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using OpenQA.Selenium.Edge;
using SeleniumExamples;

GHPTests gHPTests = new GHPTests();
//Console.WriteLine("1. Edge  2.Chrome");
//int ch = Convert.ToInt32(Console.ReadLine());
//switch(ch)
//{
//    case 1:
//        gHPTests.InitializeEdgeDriver();
//        break;

//        case 2:
//        gHPTests.InitializeChromeDriver();
//        break;


//}
/*
List<string> drivers = new List<string>();

drivers.Add("Chrome");
drivers.Add("Edge");
foreach (var d in drivers)
{
    switch (d)

    {
        case "Chrome":
            gHPTests.InitializeChromeDriver();
            break;
        case "Edge":
            gHPTests.InitializeEdgeDriver();
            break;
        
    }
         try { 
        //gHPTests.TitleTest();
        //gHPTests.PageSourceandURLTest();
        //gHPTests.GStest();
        //gHPTests.GmailLinkTest();
        //gHPTests.ImagesLinkTest();
        //gHPTests.LocalizationTest();
        gHPTests.GAppYoutubeTest(); 
    }
    catch (AssertionException)
    {
        Console.WriteLine("Title Test Failed");
    }
    gHPTests.Destruct();

*/
//}


//try
//{
//    gHPTests.TitleTest();
//    gHPTests.PageSourceandURLTest();
//    gHPTests.GStest();
//    gHPTests.GmailLinkTest();
//    gHPTests.ImagesLinkTest();
//    gHPTests.LocalizationTest();
//}
//catch(AssertionException)
//{
//    Console.WriteLine("Title Test Failed");
//}
//gHPTests.Destruct();


List<string> drivers = new List<string>();

drivers.Add("Chrome");
//drivers.Add("Edge");
foreach (var d in drivers)
{
    AmazonTests az = new AmazonTests();

    switch (d)

    {
        case "Chrome":
            az.InitializeChromeDriver();
            break;
        case "Edge":
            az.InitializeEdgeDriver();
            break;

    }
    try
    {
        //az.TitleTest();
        //az.LogoClickTest();
        //az.SearchProductTest();
        Thread.Sleep(2000);
        //az.ReloadHomePage();
        //az.TodaysDealTest();
        //az.SignInAccListTest();
        az.SearchAndFilterProductByBrandTest();
        //az.SortBySelectTest();
    }
    catch (AssertionException)
    {
        Console.WriteLine("Title Test Failed");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);

    }

   az.Destruct();


}





