using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var textService = new TextService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //subscribing to the method
            videoEncoder.VideoEncoded += textService.OnVideoEncoded;

            videoEncoder.Encode(video);
            Console.ReadLine();
        }

    }
    public class VideoEventArgs : EventArgs
    {
        //the optional event args must inherit from the EventARgs object if deciding to use it
        public Video vid { get; set; }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MailService: Sending an email..." + args.vid.Title);
        }
    }

    public class TextService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("TextService: Sending Text " + args.vid.Title);
        }
    }
}
