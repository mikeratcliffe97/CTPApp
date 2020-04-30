using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Assertions;
public class NotificationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }

    
    public void SendNotification(string title, string text, int time)
    {
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = System.DateTime.Now.AddMinutes(time);
        notification.LargeIcon = "my_icon";
        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
