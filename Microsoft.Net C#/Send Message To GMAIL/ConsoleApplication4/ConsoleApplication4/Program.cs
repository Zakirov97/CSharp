using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using S22.Imap;
using System.Net.Mail;
using System.Net;

namespace ConsoleApplication4
{
    public class MailMessageContainer
    {
        public uint Id { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public MailMessageContainer(MailMessage message, uint id)
        {
            Body = message.Body;
            Subject = message.Subject;
            Id = id;
        }
    }
    public static class GmailImapProvider
    {
        public static List<MailMessageContainer> Download(DateTime startPeriod, DateTime finishPeriod, bool makeUnseen = true)
        {
            string hostname = "imap.gmail.com",
               username = "mamkotraher.xxx", password = "qazxswedc54321qwerty";
            // The default port for IMAP over SSL is 993.

            using (ImapClient client = new ImapClient(hostname, 993, username, password, AuthMethod.Login, true))
            {
                List<uint> uids = client.Search(SearchCondition.SentSince(startPeriod).And(SearchCondition.SentBefore(finishPeriod))).ToList();
                List<MailMessage> messages = client.GetMessages(uids).ToList();

                List<MailMessageContainer> result = new List<MailMessageContainer>();

                // 
                for (int i = 0; i < messages.Count(); i++)
                {
                    result.Add(new MailMessageContainer(messages[i], uids[i]));
                    client.RemoveMessageFlags(uids[i], null, new MessageFlag[] { MessageFlag.Seen} );
                }
                return result;
            }
}

        public static void SendMessage()
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("mamkotraher.xxx@gmail.com", "qazxswedc54321qwerty");      
            MailAddress from = new MailAddress("mamkotraher.xxx@gmail.com",
              "Jane " + (char)0xD8 + " Clayton",
            System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress("iskander.raimbayev@outlook.com");
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application. ";
            message.Subject = "Check this new video from our site!";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.Send(message);
        }
    }
    #region PartOne
    public abstract class VoiceProducer
{
    public int DefaultSpeed = 0;
    public int DefaultVolume = 100;
    public abstract void Speak(string text);
    public abstract void Setup(int speed, int volume);
    public abstract void Save(string path);
}

public class RussianVoiceProducer : VoiceProducer
{
    private SpeechSynthesizer _speechSynthesizer;
    public override void Setup(int speed, int volume)
    {
        _speechSynthesizer.Rate = speed;
        _speechSynthesizer.Volume = volume;
    }

    public override void Speak(string text)
    {
        _speechSynthesizer.Speak(text);
    }

    public override void Save(string path)
    {
        _speechSynthesizer.SetOutputToWaveFile(path);
    }

    public RussianVoiceProducer()
    {
        _speechSynthesizer = new SpeechSynthesizer();
        _speechSynthesizer.Rate = DefaultSpeed;
        _speechSynthesizer.Volume = DefaultVolume;
    }

}

public class EnglishVoiceProducer : VoiceProducer
{
    private SpeechSynthesizer _speechSynthesizer;
    public override void Setup(int speed, int volume)
    {
        _speechSynthesizer.Rate = speed;
        _speechSynthesizer.Volume = volume;
    }

    public override void Speak(string text)
    {
        _speechSynthesizer.Speak(text);
    }

    public override void Save(string path)
    {
        throw new NotImplementedException();
    }

    public EnglishVoiceProducer()
    {
        _speechSynthesizer = new SpeechSynthesizer();
        _speechSynthesizer.Rate = DefaultSpeed;
        _speechSynthesizer.Volume = DefaultVolume;
        _speechSynthesizer.SelectVoice("Microsoft Zira Desktop");
    }
}

//public class JapaneseVoiceProducer : VoiceProducer
//{

//}
#endregion
class Program
{
    static void Main(string[] args)
    {
            //#region First
            //////SpeechSynthesizer sin = new SpeechSynthesizer();

            //////var allVoices = sin.GetInstalledVoices();
            //////foreach (var item in allVoices)
            //////{
            //////    Console.WriteLine(item.VoiceInfo.Name);
            //////}
            ////VoiceProducer rusProducer = new RussianVoiceProducer();
            ////VoiceProducer engProducer = new EnglishVoiceProducer();
            ////Random random = new Random();
            ////while (true)
            ////{

            ////    int numberOfTicket = random.Next(100, 300);
            ////    int numberOfWindow = random.Next(1, 20);
            ////    string rusText = $"Клиент с номером {numberOfTicket}, пожалуйста, подойдите к окну под номером {numberOfWindow}";
            ////    string engText = $"Client with number {numberOfTicket} please come to windows number {numberOfWindow}";

            ////    //producer.Save(@"C:\Users\РаимбаевИ\Databases\output.wav");
            ////    rusProducer.Speak(rusText);

            ////    engProducer.Speak(engText);

            ////    Thread.Sleep(10000);
            ////}
            ////Console.WriteLine("Completed!");


            ////string hostname = "loli228@gmail.com",
            ////     username = "ad", password = "7550199";

            ////using (ImapClient client = new ImapClient(hostname, 993, username, password, AuthMethod.Login, true))
            ////{
            ////    Console.WriteLine("We are connected!");
            ////}
            //#endregion

            //foreach (var item in GmailImapProvider.Download(new DateTime(2018, 07, 9), new DateTime(2018, 07, 12), true))
            //{
            //    Console.WriteLine(item.Id + ")\t" + item.Body + "\n" + item.Subject + "\n************************************");
            //}

            GmailImapProvider.SendMessage();
        Console.ReadLine();
    }
}
}
