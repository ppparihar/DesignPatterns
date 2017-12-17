using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.Structural
{
    /*
     *  Observer Coding Exercise
     *  
        Imagine a game where one or more rats can attack a player. Each individual sender has an Attack value of 1. However, rats attack as a swarm, so each sender's Attack value is equal to the total number of rats in play.

        Given that a sender enters play through the constructor and leaves play (dies) via its Dispose() method, please implement the Game and Rat classes so that, at any point in the game, the Attack value of a sender is always consistent.

        This exercise has two simple rules:

        The Game class cannot have properties or fields. It can only contain events and methods.
        The Rat class' Attack field is strictly a field, not a property.
     
     * */
    public class Game
    {

        // remember - no fields or properties!
        public event EventHandler RatEnters, RatDies;
        public event EventHandler<Rat> NotifyRat;

        public void FaireRateEnters(Rat sender)
        {
            RatEnters?.Invoke(sender, EventArgs.Empty);
        }
        public void FaireRateDies(Rat sender)
        {
            RatDies?.Invoke(sender, EventArgs.Empty);
        }
        public void FaireNotifyRat(Rat sender, Rat which)
        {
            NotifyRat?.Invoke(sender, which);
        }
    }

    public class Rat : IDisposable
    {
        public int Attack = 1;
        private readonly Game _game;
        public Rat(Game game)
        {
            _game = game;
            _game.NotifyRat += (sender, rat) =>
            {
                if (!ReferenceEquals(this, rat)) return;

                ++Attack;

            };
            _game.RatEnters += (sender, args) =>
            {
                if (!ReferenceEquals(this, (Rat)sender))
                {
                    ++Attack;
                    _game.FaireNotifyRat(this, (Rat)sender);
                }
            };
            _game.RatDies += (sender, args) => --Attack;

            _game.FaireRateEnters(this);
        }


        public void Dispose()
        {
            _game.FaireRateDies(this);
        }
    }
}
