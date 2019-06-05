using Hotel.Models.Entity;
using Hotel.Models.Extended;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hotel.Utils
{
    internal static class Extensions
    {
        public static bool HasDataForLogin(this User user)
        {
            return (user?.Email.Length != 0) && (user?.Password.Length != 0);
        }
        public static bool HasDataForRegister(this User user)
        {
            return (user?.FirstName.Length != 0) &&
                (user?.LastName.Length != 0) &&
                (user?.Email.Length != 0) &&
                (user?.Password.Length != 0);
        }

        public static RoomData ToData(this Room room, IEnumerable<Feature> features, IEnumerable<RoomImage> images)
        {
            return new RoomData
            {
                Room = room,
                Features = new ObservableCollection<Feature>(features),
                Images = new ObservableCollection<RoomImage>(images)
            };
        }

        public static BookingRoomData ToData(this BookingRoom bookingRoom, IEnumerable<Service> services)
        {
            return new BookingRoomData
            {
                BookingRoom = bookingRoom,
                Services = new ObservableCollection<Service>(services)
            };
        }
    }
}
