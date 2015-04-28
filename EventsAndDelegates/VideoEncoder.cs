using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsAndDelegates
{
   public class VideoEncoder
    {
        // 1 - Define a delegate (contract between publisher and subscriber)
        // 2 - Define an event based on that delegate
        //3 - Raise the event

        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args); //1. declaring a delegate - determines the signature of the subscriber


        public event VideoEncodedEventHandler VideoEncoded; //2. defining the event 

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video");
            System.Threading.Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video myVideo)
        { 
            //3. raises the event (always uses proteted virtual void)
            if (VideoEncoded != null) //null would mean that nobody is subscribed to this event
            {
                VideoEncoded(this, new VideoEventArgs() { vid = myVideo });
            }
        }
    }
}
