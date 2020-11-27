using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
//using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;
using Table = Amazon.DynamoDBv2.DocumentModel.Table;


using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace COMP306_Tahmina_Sharnjeet_Project
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //static ConsumeApi apiclass = new ConsumeApi();
       //static HttpClient client1 = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            
            //Database.SetInitializer<DBContext>(null);
            
        }

       

            //public static int count = 0;
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        Random rnd = new Random();
        internal ObservableCollection<Travel> TravelPackage { get; private set; }


        private void createTable_Click(object sender, RoutedEventArgs e)
        {

            string tableName = "Travels";
            var request = new CreateTableRequest
            {
                TableName = tableName,
                AttributeDefinitions = new List<AttributeDefinition>()
                 {
                    
                    new AttributeDefinition
                     {
                      AttributeName = "Budget",
                    AttributeType = "N"
                       },
                          new AttributeDefinition
                          {
                         AttributeName = "Destination",
                        AttributeType = "S"
                                }
                                 },
                KeySchema = new List<KeySchemaElement>()
                   {
                   
                   new KeySchemaElement
                   {
                    AttributeName = "Budget",
                    KeyType = "HASH" //Partition key
                      },
                        new KeySchemaElement
                       {
                     AttributeName = "Destination",
                    KeyType = "RANGE" //partition key
                     }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 30,
                    WriteCapacityUnits = 25
                }
            };

            var response = client.CreateTable(request);
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void budgetClear_Click(object sender, RoutedEventArgs e)
        {
            budgetTextBox.Text = "";
        }

        private void budgetTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void searchTravelPackageButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow f2 = new SecondWindow();
       
            f2.destinationLabel.Content = "Destination: " + destinationSelectionBox.SelectionBoxItem;
            f2.budgetLabel.Content = "Budget: $" + budgetTextBox.Text;
            f2.Show();
            Close();



            Table table = Table.LoadTable(client, "Travels");
            var travel = new Document();
           
            int bgt = int.Parse(budgetTextBox.Text);
            String des = (string)destinationSelectionBox.SelectionBoxItem;
          
            travel["Budget"] = bgt;
            travel["Destination"] = des;

            table.PutItem(travel);





           


    }
    }
}
    

