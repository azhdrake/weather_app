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
      InitializeComponent();
    }

    private void btbGetWeather_Click(object sender, EventArgs e)
    {
    // disables the button while the API call is happening.
      btbGetWeather.Enabled = false;

    // Get's the city and state text and does a whole lotta verification on them.
      string city = txtCity.Text;
      string state = txtState.Text;

      if (LocationDataValid(city, state, out string error))
      {
        if (VerifyLength(city, 3))
        {
          if(VerifyLength(state, 2))
          { 
            if (VerifyStateName(state)) 
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
              }
              else
              {
                MessageBox.Show("Please don't include numbers city and state inputs", "Error");
              }
            }
            else
            {
              MessageBox.Show("State not valid.", "Error");
            }
          }
          else
          {
            MessageBox.Show("State name needs to be at least 2 characters long", "Error");
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

    private bool GetWeatherText(string city, string state, out string weatherText, out string errorMessage)
    {
    // the api call.
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
    // verification that city and state strings are not empty.
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
    //verification that there are no numaric characters in the a strings.
      foreach (char c in testString)
      {
        if (Char.IsNumber(c))
        {
          return false;
        }
      }
      return true;
    }

    private bool VerifyStateName(string potentialState)
    {
    // verification that the state name is a real state or state code. 
      Dictionary<string, string> states = GetAllStates();
      foreach (KeyValuePair<string, string> state in states)
      {
        if(potentialState.ToLower() == state.Key.ToLower() || potentialState.ToLower() == state.Value.ToLower())
        {
          return true;
        }
      }
      return false;
    }

    private Dictionary<string, string> GetAllStates()
      {
      // it's just a dictionary of all the state codes and names.
      Dictionary<string, string> states = new Dictionary<string, string>();

      states.Add("AL", "Alabama");
      states.Add("AK", "Alaska");
      states.Add("AZ", "Arizona");
      states.Add("AR", "Arkansas");
      states.Add("CA", "California");
      states.Add("CO", "Colorado");
      states.Add("CT", "Connecticut");
      states.Add("DE", "Delaware");
      states.Add("DC", "District of Columbia");
      states.Add("FL", "Florida");
      states.Add("GA", "Georgia");
      states.Add("HI", "Hawaii");
      states.Add("ID", "Idaho");
      states.Add("IL", "Illinois");
      states.Add("IN", "Indiana");
      states.Add("IA", "Iowa");
      states.Add("KS", "Kansas");
      states.Add("KY", "Kentucky");
      states.Add("LA", "Louisiana");
      states.Add("ME", "Maine");
      states.Add("MD", "Maryland");
      states.Add("MA", "Massachusetts");
      states.Add("MI", "Michigan");
      states.Add("MN", "Minnesota");
      states.Add("MS", "Mississippi");
      states.Add("MO", "Missouri");
      states.Add("MT", "Montana");
      states.Add("NE", "Nebraska");
      states.Add("NV", "Nevada");
      states.Add("NH", "New Hampshire");
      states.Add("NJ", "New Jersey");
      states.Add("NM", "New Mexico");
      states.Add("NY", "New York");
      states.Add("NC", "North Carolina");
      states.Add("ND", "North Dakota");
      states.Add("OH", "Ohio");
      states.Add("OK", "Oklahoma");
      states.Add("OR", "Oregon");
      states.Add("PA", "Pennsylvania");
      states.Add("RI", "Rhode Island");
      states.Add("SC", "South Carolina");
      states.Add("SD", "South Dakota");
      states.Add("TN", "Tennessee");
      states.Add("TX", "Texas");
      states.Add("UT", "Utah");
      states.Add("VT", "Vermont");
      states.Add("VA", "Virginia");
      states.Add("WA", "Washington");
      states.Add("WV", "West Virginia");
      states.Add("WI", "Wisconsin");
      states.Add("WY", "Wyoming");

      return states;
    }
  }
}
