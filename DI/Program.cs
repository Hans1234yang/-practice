using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DI
{
    class Program
    {
        static UnityContainer container = new UnityContainer();

        static void init()
        {
            container.RegisterType <IPlayer,Player>();
            container.RegisterType<IFile, File>();
        }


        static void Main(string[] args)
        {
            ///1.普通方式注入
            Userdo userdo1 = new Userdo(new File(),new Player());
            userdo1.StartPlay();

            ///2.使用unity注入

            Userdo userdo = container.Resolve<Userdo>();
            userdo.StartPlay();
            
        }
    }

    ///用户使用 不依赖 播放器，依赖 播放器接口 
    ///用户使用 不依赖 文件， 依赖 文件接口
    /// 播放器 不依赖 文件 依赖于 文件接口
    // 播放器接口 不依赖 文件， 依赖于文件接口 

    public class Userdo
    {
        IFile _IFile;
        IPlayer _Iplayer;
        public Userdo(File theIFile, Player theIplayer)
        {
            _IFile = theIFile;
            _Iplayer = theIplayer;
        }
        public void StartPlay()
        {
            _Iplayer.PlayVideo(_IFile);
        }
    }

    public class File : IFile
    {
        public string filename { get; set; }
    }

    public interface IFile
    {
        string filename { get; set; }
    }

    public class Player : IPlayer
    {
        public void PlayVideo(IFile file)
        {
            Console.WriteLine(file.filename);
        }
    }
    public interface IPlayer
    {
        void PlayVideo(IFile file);
    }
}
