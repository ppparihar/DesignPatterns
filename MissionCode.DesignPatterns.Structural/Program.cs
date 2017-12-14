using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionCode.DesignPatterns.Structural
{
    class Program
    {
        static void Main(string[] args)
        {
            Composite();
        }

        static void Composite()
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();
            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(neuron2);
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
}
