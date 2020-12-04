using System;
using System.Collections.Generic;
using System.Text;

namespace Baseline
{
    class Numeric_Methods
    {

        public static double get_normal(double x, double mu, double sigma)
        {
            double p1 = Math.Exp(-(x - mu) * (x - mu) / (2 * (sigma * sigma)));
            double p2 = ((Math.Sqrt(2 * Math.PI)) * sigma);
            return p1 / p2;
        }
        public static List<List<double>> run_Monte_Carlo(int number_of_simulation,int number_of_steps ,string model_name,List<double> extra_parameters)
        {
            List<List<double>> results = new List<List<double>>();

            for(int sumulation_nb = 0; sumulation_nb < number_of_simulation; sumulation_nb++)
            {
                List<double>  local_processus = new List<double>();
                for (int step=0;step< number_of_steps; step++)
                {

                    double discrete_step = 0;
                    if (model_name == "Gaussian process")
                    {
                        Random random = new Random();
                        discrete_step = get_normal(random.NextDouble(), extra_parameters[0], extra_parameters[1]);
                    }

                    if (model_name == "CIR")
                    {
                        Random random = new Random();
                        discrete_step = get_normal(random.NextDouble(), extra_parameters[0], extra_parameters[1]);
                    }
                    local_processus.Add(local_processus[-1] * (1 + discrete_step));
                }
                results.Add(local_processus);



            }

            return results;
        }
    }
}
