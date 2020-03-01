using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace WeatherApp
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      // 
      InitializeComponent();
      cmbStates.Items.AddRange(states);
    }

    string[] states = {"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado","Connecticut", "Delaware", "District of Columbia", "Florida", "Georgia", "Hawaii","Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine","Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri","Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York","North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania","Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah","Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };

    private void btbGetWeather_Click(object sender, EventArgs e)
    {
      btbGetWeather.Enabled = false;

      string city = txtCity.Text;
      string state = cmbStates.Text;

      if (LocationDataValid(city, state, out string error))
      {
        if (VerifyLength(city, 3))
        {
            if (CheckForNumericCharacters(city) && CheckForNumericCharacters(state))
            {
              if (GetWeatherText(city, state, out string weather, out string textErrorMessage))
              {
                lblWeatherText.Text = weather;
                
              }
              else
              {
                MessageBox.Show(textErrorMessage, "Error");
              }
              if (GetWeatherImage(city, state, out Image weatherImage, out string errorMessage))
            {
              pbWeatherImage.Image = weatherImage;
            }
            else
            {
              MessageBox.Show(errorMessage, "Error");
            }
            }
            else
            {
              MessageBox.Show("Please don't include numbers city and state inputs", "Error");
            }
        }
        else
        {
          MessageBox.Show("City name needs to be at least 3 characters long.", "Error");
        }
      }
      else
      {
        MessageBox.Show(error, "Error");
      }
      btbGetWeather.Enabled = true;
    }

    private bool VerifyLength(string toVerify, int minLength)
    {
      if (toVerify.Length >= minLength)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool GetWeatherImage(string city, string state, out Image weatherImage, out string errorMessage)
    {
      weatherImage = null;
      errorMessage = null;

      try
      {
        using (WebClient client = new WebClient())
        {
          string baseUrl = "http://weather-csharp.herokuapp.com/";
          string weatherPhotoUrl = String.Format("{0}photo?city={1}&state={2}", baseUrl, city, state);
          string tempFileDirectory = System.IO.Path.GetTempPath().ToString();
          String weatherFilePath = System.IO.Path.Combine(tempFileDirectory, "weather_image.jpeg");
          Debug.WriteLine(weatherFilePath);
          client.DownloadFile(weatherPhotoUrl, weatherFilePath);
          weatherImage = Image.FromFile(weatherFilePath);
        }
        return true;
      } catch(Exception e)
      {
        Debug.WriteLine(e.StackTrace);
        errorMessage = e.Message;
        return false;
      }
    }

    private bool GetWeatherText(string city, string state, out string weatherText, out string errorMessage)
    {
      string baseUrl = "http://weather-csharp.herokuapp.com/";
      string weatherTextUrl = String.Format("{0}text?city={1}&state={2}", baseUrl, city, state);
      weatherText = null;
      errorMessage = null;

      try
      {
        using (WebClient client = new WebClient())
        {
          weatherText = client.DownloadString(weatherTextUrl);
          return true;
        }
        Debug.WriteLine(weatherText);
      }
      catch (Exception e)
      {
        Debug.WriteLine(e.StackTrace);
        errorMessage = e.Message;
        return false;
      }
    }
    private bool LocationDataValid(string city, string state, out string errorMessage)
    {
      errorMessage = null;
      if (String.IsNullOrWhiteSpace(city))
      {
        errorMessage = "Please input a value for 'city'";
        return false;
      }
      if (String.IsNullOrWhiteSpace(state))
      {
        errorMessage = "Please input a value for 'state'";
        return false;
      }
      return true;
    }
    private bool CheckForNumericCharacters(string testString)
    {
      foreach (char c in testString)
      {
        if (Char.IsNumber(c))
        {
          return false;
        }
      }
      return true;
    }
  }
}
