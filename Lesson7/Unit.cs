namespace Lesson7
{
    public abstract class Unit
    {
        private double _hp;
        private double _ad;
        private double _attackCof;
        private double _damage;

        public double HealthPoints
        {
            get { return _hp; }
            set { _hp = value; }
        }

        public double AttackCof
        {
            get { return _attackCof; }
        }

        public double AttackDamage
        {
            get { return _ad; }
        }

        public double DamageTaken
        {
            get { return _damage; }
            set { _damage = value; }
        }

        public Unit(double healthPoints, double attackDamage, double attackCof)
        {
            if (healthPoints > 0)
            {
                _hp = healthPoints;
            }
            else
            {
                death();
            }

            if (attackDamage > 0)
            {
                _ad = attackDamage;
            }
            else
            {
                noDamage();
            }

            if (attackCof >= 0)
            {
                _attackCof = attackCof;
            }
            else
            {
                death();
            }
        }

        public virtual double Attack(Unit unit)
        {
            if (Defence() >= AttackDamage)
            {
                Defence();
            }

            unit.DamageTaken = AttackDamage * AttackCof;
            return unit.DamageTaken;
        }

        public double Defence()
        {
            throw new System.NotImplementedException();
        }


        private void noDamage()
        {
            throw new System.NotImplementedException();
        }

        private void death()
        {
            throw new System.NotImplementedException();
        }
    }
}