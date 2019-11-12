using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace EmergenSEAT.Model
{
    public class DataHandler
    {
        public static void ExportToJson(string filePath, string fileName, Object json)
        {
            string completePath = filePath + '/' + fileName;
            File.WriteAllText(completePath, JsonConvert.SerializeObject(json));
        }

        public static List<UserProfile> ImportFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            var data = JsonConvert.DeserializeObject<List<UserProfile>>(json);
            return data;
        }

        public static List<UserProfile> ConvertJsonToProfile(UserProfile data)
        {
            var profiles = new List<UserProfile>();

            foreach (UserProfile s in profiles)
            {
                UserProfile profile = new UserProfile(s.Email, s.FirstName, s.LastName, s.Password);
                foreach (CarSeat seat in s.CarSeats)
                {
                    CarSeat car_seat = new CarSeat(seat.SerialNumber, seat.Model, seat.Latitude, seat.Longitude, seat.Weight, seat.Temperature);
                    car_seat.SetGPSLocation(seat.Latitude, seat.Longitude);
                    car_seat.SetTemperature(seat.Temperature, seat.TemperatureUnit);
                    car_seat.SetWeight(seat.Weight, seat.WeightUnit);
                    profile.AddCarSeat(car_seat);
                }
                profiles.Add(profile);
            }

            return profiles;

        }
    }
}
