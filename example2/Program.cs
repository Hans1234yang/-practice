using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 依赖倒置
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    ///用户使用播放器 放文件， 不依赖于 文件， 依赖于文件接口 
    // 用户使用播放器 放文件， 不依赖于 播放器 ，依赖于 播放器接口

    //播放器 不依赖 文件， 而是 依赖 文件 接口 

    // 播放器 接口 不依赖 文件， 而是依赖于  文件接口 


    public class UserPlay
    {
        IPlayer _player = new Player();
        IFile _file = new File();

       public void start()
        {
            _player.playfile(_file);
        }
    }

    public class Player : IPlayer
    {
        public void playfile(IFile _file)
        {
            Console.WriteLine(_file.filename);
        }
    }
    public interface IPlayer
    {
        void playfile(IFile _file);
    }

    public class File : IFile
    {
        public string filename { get; set; }
    }
    public interface IFile
    {
        string filename { get; set; }
    }

}
