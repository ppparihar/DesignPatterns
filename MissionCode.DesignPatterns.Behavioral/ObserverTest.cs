using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace MissionCode.DesignPatterns.Behavioral
{

    [TestFixture]
    public class ObserverTest
    {
        [Test]
        public void PlayingByTheRules()
        {
            Assert.That(typeof(Game).GetFields(), Is.Empty);
            Assert.That(typeof(Game).GetProperties(), Is.Empty);
        }

        [Test]
        public void SingleRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(1));
        }

        [Test]
        public void TwoRatTest()
        {
            var game = new Game();
            var rat = new Rat(game);
            var rat2 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));
        }

        [Test]
        public void ThreeRatsOneDies()
        {
            var game = new Game();

            var rat = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(1));

            var rat2 = new Rat(game);
            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));

            using (var rat3 = new Rat(game))
            {
                Assert.That(rat.Attack, Is.EqualTo(3));
                Assert.That(rat2.Attack, Is.EqualTo(3));
                Assert.That(rat3.Attack, Is.EqualTo(3));
            }

            Assert.That(rat.Attack, Is.EqualTo(2));
            Assert.That(rat2.Attack, Is.EqualTo(2));
        }
    }
}

