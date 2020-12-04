using System;
using System.Collections.Generic;
using System.Text;


namespace Baseline
{
    class Options
    {
        private double strike;
        private double current_underlying_price;
        private double time_to_maturity_h;
        private double fixed_rate;
        private bool is_a_call;
        private double iv;
        private List<double> greeks;

        public  Options(double strike_l,double time_to_maturity_l,double fixed_rate_l,bool is_a_call_l)
        {
            this.strike = strike_l;
            this.time_to_maturity_h = time_to_maturity_l;
            this.fixed_rate = fixed_rate_l;
            this.is_a_call = is_a_call_l;
            this.greeks = new List<double>();
            this.greeks.Add(0);//Delta
            this.greeks.Add(0);// Gamma
            this.greeks.Add(0);//Vega
            this.greeks.Add(0);//Tetha

        }

        public double get_normal(double x, double mu, double sigma)
        {
            double p1 = Math.Exp(-(x - mu) * (x - mu) / (2 * (sigma * sigma)));
            double p2 = ((Math.Sqrt(2 * Math.PI)) * sigma);
            return p1 / p2;
        }

        public double get_Monte_Carlo_price(double number_of_simulations, double number_of_steps, double mu,double sigma)
        {

            return 0;
        }
        public void calculate_greeks()
        {
            this.greeks[0] = 0;
            this.greeks[1] = 0;
            this.greeks[2] = 0;
            this.greeks[3] = 0;
        }
        public double get_bns_price()
        {

            double d1 = (Math.Log(this.current_underlying_price/this.strike)+(this.fixed_rate+this.iv* this.iv / 2)*time_to_maturity_h/(360*24))/(this.iv*Math.Sqrt(time_to_maturity_h / (360 * 24)));
            double d2 = d1-this.iv*Math.Sqrt(time_to_maturity_h / (360 * 24));

            if(is_a_call) return this.current_underlying_price*get_normal(d1,0,1)-this.strike*Math.Exp(-this.fixed_rate*this.time_to_maturity_h/(360*24))*get_normal(d2,0,1);
            else return -this.current_underlying_price * get_normal(-d1, 0, 1) + this.strike * Math.Exp(-this.fixed_rate * this.time_to_maturity_h / (360 * 24)) * get_normal(-d2, 0, 1);

        }

        public double get_IV_approximation()
        {

            return 0;
        }


        public double get_other_side_from_cp_parity()
        {

            return 0;
        }

    }


}
