using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单纯依赖
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

     ///用户播放媒体文件
     public class OperatioMain
    {
        public void plyerMedia()
        {
            MediaFile _mediaFile = new MediaFile();
            Player _player = new Player();
            _player.Play(_mediaFile);
        }    
        
    }

    ///播放器
    public class Player
    {
        public void Play(MediaFile file)
        {
            Console.WriteLine("已经播放{0}",file.FilePath);
        }
    }

    ///媒体文件
    public class MediaFile
    {
        public string FilePath { get; set; }
    }

    //播放器 依赖 文件
    //用户使用播放器放文件，依赖播放器
    //用户使用播放器放文件, 依赖 文件 
}
