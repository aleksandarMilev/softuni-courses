
namespace SocialMediaManager.Tests;

    public class UnitTest1
    {
        [Test]
        public void Ctor()
        {
            InfluencerRepository ir = new();
            Assert.IsNotNull(ir);
        }

        [Test]
        public void RegisterInfluencer1()
        {
            InfluencerRepository ir = new();
            Influencer inf = null;
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => ir.RegisterInfluencer(inf));
        }

        [Test]
        public void RegisterInfluencer2()
        {
            InfluencerRepository ir = new();

            Influencer inf1 = new Influencer("pesho", 20);
            Influencer inf2 = new Influencer("pesho", 20);

            ir.RegisterInfluencer(inf1);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => ir.RegisterInfluencer(inf2));
        }

        [Test]
        public void RegisterInfluencer3()
        {
            List<Influencer> expected = new();
            InfluencerRepository ir = new();

            Influencer inf1 = new Influencer("pesho", 20);

            expected.Add(inf1);
            ir.RegisterInfluencer(inf1);

            Assert.AreEqual(expected, ir.Influencers);
        }

        [Test]
        public void RegisterInfluencer4()
        {
            InfluencerRepository ir = new();
            Influencer inf1 = new Influencer("pesho", 20);

            Assert.AreEqual($"Successfully added influencer pesho with 20", ir.RegisterInfluencer(inf1));
        }

        [Test]
        public void RemoveInfluencer1()
        {
            InfluencerRepository ir = new();
            Influencer inf1 = null;

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => ir.RegisterInfluencer(inf1));
        }

        [Test]
        public void RemoveInfluencer2()
        {
            InfluencerRepository ir = new();
            Influencer inf1 = new Influencer("pesho", 20);
            ir.RegisterInfluencer(inf1);

            Assert.IsTrue(ir.RemoveInfluencer("pesho"));
        }

        [Test]
        public void RemoveInfluencer3()
        {
            InfluencerRepository ir = new();
            Influencer inf1 = new Influencer("pesho", 20);
            ir.RegisterInfluencer(inf1);

            Assert.IsFalse(ir.RemoveInfluencer("asddsa"));
        }

        [Test]
        public void GetInfluencerWithMostFollowers()
        {
            InfluencerRepository ir = new();

            Influencer inf1 = new Influencer("pesho", 20);
            ir.RegisterInfluencer(inf1);

            Influencer inf2 = new Influencer("pes21313ho", 30);
            ir.RegisterInfluencer(inf2);

            Influencer inf3 = new Influencer("pesadssaho", 40);
            ir.RegisterInfluencer(inf3);

            Assert.AreEqual(inf3, ir.GetInfluencerWithMostFollowers());
        }

        [Test]
        public void GetInfluencer()
        {
            InfluencerRepository ir = new();

            Influencer inf1 = new Influencer("pesho", 20);
            ir.RegisterInfluencer(inf1);

            Influencer inf2 = new Influencer("pes21313ho", 30);
            ir.RegisterInfluencer(inf2);

            Influencer inf3 = new Influencer("pesadssaho", 40);
            ir.RegisterInfluencer(inf3);

            Assert.AreEqual(inf2, ir.GetInfluencer("pes21313ho"));
        }
    }