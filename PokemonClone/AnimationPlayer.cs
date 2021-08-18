using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone
{
    public static class AnimationPlayer
    {
        public static void Play(Action action)
        {
            action.Invoke();
        }
        public static void Play(Action action, IAnimation animation)
        {
            if (animation.IsDone)
            {
                action.Invoke();
            }
            
        }
    }
}
