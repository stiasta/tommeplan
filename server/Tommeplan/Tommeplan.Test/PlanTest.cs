using NUnit.Framework;
using System.Linq;

namespace Tommeplan.Test
{
    public class PlanTest
    {
        [TestFixture]
        public class FromTRV
        {
            [Test]
            public void WithDataSet_ShouldReturn52Weeks()
            {
                var plan = Plan.FromTRV(Data());
                Assert.AreEqual(52, plan.Weeks.Count());
            }

            [Test]
            public void WithDataSet_ShouldContainsNumbers1Through52()
            {
                var weeks = Plan.FromTRV(Data()).Weeks.ToList();
                for (int i = 1; i <= 52; i++)
                {
                    Assert.AreEqual(i, weeks[i - 1].WeekNumber);
                }
            }

            [Test]
            public void WithDataSet_ShouldReturnFirstWeeksTypeAsRestavfall()
            {
                var week = Plan.FromTRV(Data()).Weeks.First().Types.First().ToLower();
                Assert.AreEqual("restavfall", week);
            }

            [Test]
            public void WithDataSet_ShouldReturnFirstWeeksTypesCountAs1()
            {
                var numTypes = Plan.FromTRV(Data()).Weeks.First().Types.Count();
                Assert.AreEqual(1, numTypes);
            }

            private string Data()
            {
                return @"<div class='tommeplan-fullyear no-show-days'>
		                <div class='legend'>
			                <div class='legend-box tomming-papp_papir'>Papp / Papir</div>
			                <div class='legend-box tomming-plast'>Plast</div>
			                <div class='legend-box tomming-rest'>Restavfall</div>
			                <div class='tommeplancode'>P7</div>
			
			                <div class='print-button' data-sirconclick='print-year-tommeplan' data-cachefilename='145257_0'>Skriv ut</div>
			                <h4 style='margin:0;'>2016</h4>
		                </div>
		                <div class='columns'>
		                <div class='column'><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 01</h4><div class='tomme-weekdates'>04.01-10.01</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 02</h4><div class='tomme-weekdates'>11.01-17.01</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 03</h4><div class='tomme-weekdates'>18.01-24.01</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div><div class='single-tomming tomming-juletre'>
					                <span class='tomming-name'>Juletreinnsamling</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 04</h4><div class='tomme-weekdates'>25.01-31.01</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 05</h4><div class='tomme-weekdates'>01.02-07.02</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 06</h4><div class='tomme-weekdates'>08.02-14.02</div><div class='single-tomming tomming-tommefri-uke'>
					                <span class='tomming-name'>Tømmefri uke</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 07</h4><div class='tomme-weekdates'>15.02-21.02</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 08</h4><div class='tomme-weekdates'>22.02-28.02</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 09</h4><div class='tomme-weekdates'>29.02-06.03</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 10</h4><div class='tomme-weekdates'>07.03-13.03</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 11</h4><div class='tomme-weekdates'>14.03-20.03</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 12</h4><div class='tomme-weekdates'>21.03-27.03</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 13</h4><div class='tomme-weekdates'>28.03-03.04</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 14</h4><div class='tomme-weekdates'>04.04-10.04</div><div class='single-tomming tomming-tommefri-uke'>
					                <span class='tomming-name'>Tømmefri uke</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 15</h4><div class='tomme-weekdates'>11.04-17.04</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 16</h4><div class='tomme-weekdates'>18.04-24.04</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 17</h4><div class='tomme-weekdates'>25.04-01.05</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 18</h4><div class='tomme-weekdates'>02.05-08.05</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --></div><div class='column'><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 19</h4><div class='tomme-weekdates'>09.05-15.05</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div><div class='single-tomming tomming-hageavfall'>
					                <span class='tomming-name'>Hageavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 20</h4><div class='tomme-weekdates'>16.05-22.05</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 21</h4><div class='tomme-weekdates'>23.05-29.05</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 22</h4><div class='tomme-weekdates'>30.05-05.06</div><div class='single-tomming tomming-tommefri-uke'>
					                <span class='tomming-name'>Tømmefri uke</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 23</h4><div class='tomme-weekdates'>06.06-12.06</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 24</h4><div class='tomme-weekdates'>13.06-19.06</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 25</h4><div class='tomme-weekdates'>20.06-26.06</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 26</h4><div class='tomme-weekdates'>27.06-03.07</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 27</h4><div class='tomme-weekdates'>04.07-10.07</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 28</h4><div class='tomme-weekdates'>11.07-17.07</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 29</h4><div class='tomme-weekdates'>18.07-24.07</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 30</h4><div class='tomme-weekdates'>25.07-31.07</div><div class='single-tomming tomming-tommefri-uke'>
					                <span class='tomming-name'>Tømmefri uke</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 31</h4><div class='tomme-weekdates'>01.08-07.08</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 32</h4><div class='tomme-weekdates'>08.08-14.08</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 33</h4><div class='tomme-weekdates'>15.08-21.08</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 34</h4><div class='tomme-weekdates'>22.08-28.08</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 35</h4><div class='tomme-weekdates'>29.08-04.09</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 36</h4><div class='tomme-weekdates'>05.09-11.09</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --></div><div class='column'><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 37</h4><div class='tomme-weekdates'>12.09-18.09</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 38</h4><div class='tomme-weekdates'>19.09-25.09</div><div class='single-tomming tomming-tommefri-uke'>
					                <span class='tomming-name'>Tømmefri uke</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 39</h4><div class='tomme-weekdates'>26.09-02.10</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 40</h4><div class='tomme-weekdates'>03.10-09.10</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 41</h4><div class='tomme-weekdates'>10.10-16.10</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 42</h4><div class='tomme-weekdates'>17.10-23.10</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 43</h4><div class='tomme-weekdates'>24.10-30.10</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 44</h4><div class='tomme-weekdates'>31.10-06.11</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 45</h4><div class='tomme-weekdates'>07.11-13.11</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 46</h4><div class='tomme-weekdates'>14.11-20.11</div><div class='single-tomming tomming-tommefri-uke'>
					                <span class='tomming-name'>Tømmefri uke</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 47</h4><div class='tomme-weekdates'>21.11-27.11</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 48</h4><div class='tomme-weekdates'>28.11-04.12</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 49</h4><div class='tomme-weekdates'>05.12-11.12</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 50</h4><div class='tomme-weekdates'>12.12-18.12</div><div class='single-tomming tomming-plast'>
					                <span class='tomming-name'>Plastemballasje</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 51</h4><div class='tomme-weekdates'>19.12-25.12</div><div class='single-tomming tomming-rest'>
					                <span class='tomming-name'>Restavfall</span></div></div><!-- tomme-week --><div class='tomme-week'>
			                <h4 class='tomme-week-title'>Uke 52</h4><div class='tomme-weekdates'>26.12-01.01</div><div class='single-tomming tomming-papp_papir'>
					                <span class='tomming-name'>Papp/Papir</span></div></div><!-- tomme-week --></div>
	                </div>";
            }
        }

        [TestFixture]
        public class ParseStreetFromTRV
        {
            [Test]
            public void WithDataSet_ShouldReturn145257()
            {
                var id = Plan.ParseStreetIdFromTRV(Data());
                Assert.AreEqual(145257, id);
            }

            private string Data()
            {
                return @"1<div id='adresseliste - dropdown'><div class='adr - option' data-adrid='145257'>Blåklokkevegen</div></div>";
            }
        }

        [TestFixture]
        public class FromHRA
        {
            [Test]
            public void WithDataSet_ShouldReturn52Weeks()
            {
                var plan = Plan.FromHRA("storetjernsvegen", Data());
                Assert.AreEqual(52, plan.Weeks.Count());
            }

            [Test]
            public void WithDataSet_ShouldContainsNumbers1Through52()
            {
                var weeks = Plan.FromHRA("storetjernsvegen", Data()).Weeks.ToList();
                for (int i = 1; i <= 52; i++)
                {
                    Assert.AreEqual(i, weeks[i - 1].WeekNumber);
                }
            }

            [Test]
            public void WithDataSet_ShouldReturnFirstWeeksTypeAsTømmefriUke()
            {
                var week = Plan.FromHRA("storetjernsvegen", Data()).Weeks.First().Types.First().ToLower();
                Assert.AreEqual("tømmefri uke", week);
            }

            [Test]
            public void WithDataSet_ShouldReturnFirstWeeksTypesCountAs1()
            {
                var numTypes = Plan.FromHRA("storetjernsvegen", Data()).Weeks.First().Types.Count();
                Assert.AreEqual(1, numTypes);
            }

            private string Data()
            {
                return @"<body>

<div id='art-main'>
<a href='http://www.hra.no/index.php'><header class='art-header'>
    <div class='art-shapes'>
        
            </div>






                
                    
  </header></a>
<nav class='art-nav desktop-nav'>
    
<a href='#' class='art-menu-btn'><span></span><span></span><span></span></a><ul class='art-hmenu'><li class='item-101'><a href='/index.php'>Hjem</a></li><li class='item-102'><a href='/index.php/apningstider'>Åpningstider</a></li><li class='item-103 active deeper parent'><a class='active separator' href='#'>Tømmeruter</a><ul class='art-hmenu-left-to-right'><li class='item-104'><a href='/index.php/tommeruter/tommeruter-for-gran'>Tømmeruter for Gran</a></li><li class='item-105'><a href='/index.php/tommeruter/tommeruter-for-hole'>Tømmeruter for Hole</a></li><li class='item-106 current active'><a class='active' href='/index.php/tommeruter/tommeruter-for-jevnaker'>Tømmeruter for Jevnaker</a></li><li class='item-107'><a href='/index.php/tommeruter/tommeruter-for-lunner'>Tømmeruter for Lunner</a></li><li class='item-108'><a href='/index.php/tommeruter/tommeruter-for-ringerike'>Tømmeruter for Ringerike</a></li></ul></li><li class='item-109 deeper parent'><a class='separator' href='#'>Gjenvinningsstasjoner</a><ul class='art-hmenu-left-to-right'><li class='item-110'><a href='/index.php/gjenvinningsstasjoner/svingerud-i-hole'>Svingerud i Hole</a></li><li class='item-111'><a href='/index.php/gjenvinningsstasjoner/nes-i-adal'>Nes i Ådal</a></li><li class='item-112'><a href='/index.php/gjenvinningsstasjoner/sokna-gjenvinningsstasjon'>Sokna i Ringerike</a></li><li class='item-113'><a href='/index.php/gjenvinningsstasjoner/trollmyra-i-jevnaker'>Trollmyra i Jevnaker</a></li><li class='item-114'><a href='/index.php/gjenvinningsstasjoner/roa-i-lunner'>Roa i Lunner</a></li><li class='item-115'><a href='/index.php/gjenvinningsstasjoner/mohagen-i-gran'>Mohagen i Gran</a></li></ul></li><li class='item-116'><a href='/index.php/kontakt-oss'>Kontakt oss</a></li><li class='item-117'><a href='/index.php/om-hra'>Om HRA</a></li></ul> 
    </nav>
<div class='art-sheet clearfix'>
            <div class='art-layout-wrapper'>
                <div class='art-content-layout'>
                    <div class='art-content-layout-row'>
                        <div class='art-layout-cell art-sidebar1'>
<div class='art-vmenublock clearfix'><div class='art-vmenublockheader'><h3 class='t'>Innhold:</h3></div><div class='art-vmenublockcontent'><ul class='art-vmenu'><li class='item-200 deeper parent'><a class='separator'>Avfallsløsninger</a><ul><li class='item-184'><a href='/index.php/avfalls2losninger/dunker'>Avfallsdunker</a></li><li class='item-186'><a href='/index.php/avfalls2losninger/avfallslosninger-nedgravde'>Nedgravd løsning</a></li></ul></li><li class='item-130'><a href='/index.php/avfallssortering-naeringsliv'>Avfallssortering næringsliv</a></li><li class='item-142'><a href='/index.php/avfallssortering-privat'>Avfallssortering privat</a></li><li class='item-128'><a href='/index.php/husholdningsrenovasjon'>Husholdningsrenovasjon</a></li><li class='item-129'><a href='/index.php/hytterenovasjon'>Hytterenovasjon</a></li><li class='item-158'><a href='http://www.hra.no/images/PDF_filer/infobrosjyre_2012.pdf' target='_blank'>Infobrosjyre</a></li><li class='item-166'><a href='/index.php/meld-fra-om-vond-lukt'>Luktregistrering</a></li><li class='item-134'><a href='/index.php/utlevering-av-pose-og-sekk-til-plastavfall'>Når får du poser og sekker</a></li><li class='item-154'><a href='/index.php/prisliste-foretak'>Prisliste næringsliv</a></li><li class='item-132'><a href='/index.php/prislister'>Prisliste privatpersoner</a></li><li class='item-160'><a href='http://www.hra.no/images/PDF_filer/renovasjonsforskrift.pdf' target='_blank'>Renovasjonsforskriften</a></li><li class='item-136'><a href='/index.php/salgsprodukter'>Salgsprodukter</a></li><li class='item-153'><a href='/index.php/sorteringsguide'>Sortere.no</a></li><li class='item-135'><a href='/index.php/skjemaer'>Søknadsskjemaer</a></li><li class='item-159'><a href='http://www.hra.no/images/PDF_filer/Arsrapport2015.pdf' target='_blank'>Årsrapport</a></li></ul></div></div>



                        </div>

                        <div class='art-layout-cell art-content'>
<article class='art-post'><div class='art-postcontent clearfix'>
<div class='breadcrumbs'>
<span>Tømmeruter</span></div>
</div></article><article class='art-post art-messages' style='display: none;'><div class='art-postcontent clearfix'>
<div id='system-message-container'>
</div></div></article><div class='item-page' itemscope='' itemtype='http://schema.org/Article'><article class='art-post'><h2 class='art-postheader'><a href='/index.php/tommeruter/tommeruter-for-jevnaker'>Tømmeruter Jevnaker 2016</a></h2><div class='art-postcontent clearfix'><div class='art-article'><table border='0' style='border-collapse: collapse;' cellspacing='0' cellpadding='0'>
<tbody>
<tr style='height: 19.85pt;'>
<td colspan='2' style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>
<p style='line-height: 15.6pt; margin-right: 10.3pt;'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>ORDINÆRE&nbsp;TØMMERUTER</span></strong></p>
<p style='line-height: 15.6pt; margin-right: 10.3pt;'><strong><span style='color: red; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tallene refererer&nbsp;til ukenummer</span></strong></p>
<p style='line-height: 15.6pt; margin-right: 10.3pt;'><span style='color: #333333; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tips: For&nbsp;enklest mulig å finne ut tømmetidene der DU bor, kan du med de fleste &nbsp; browsere søke med CTRL+F (evt eple+f om du har Mac). Skriv deretter inn ditt&nbsp;bosted (f.eks.&nbsp;veinavn), og trykk på Enter. Finner du ikke noe ved &nbsp; første søk, prøv å søke på et annet navn som kan likne.</span><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>&nbsp;&nbsp;</span></p>
<p>&nbsp;</p>
</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' valign='top' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Onsdag uke: &nbsp; 2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,52</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' valign='top' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tirsdag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>4,8,12,16,20,24,28,32,36,40,44,48,52</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Anviseren</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bakkavegen 1-24</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bassengvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergerbakkvegen &nbsp; 4-22, 24, 30, 32</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergsetvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergstien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Blinken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Blåbærveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bogavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bringebærveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Buttentjernsveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Dalstubben</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Dr. Hvattums veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Dølerudvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Frydenlundstaje</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Frydenlundsvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Furukollen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hammersborgvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Jørgen Jahrens veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Klebersteinsvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Klokkerbakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kreklingvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Liavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Markvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nordhagenvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nøklebygata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nøklebystubben</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Peder Nordbys veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Pilen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Rabbavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Randsborg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Randsborggata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sigurd Dahls veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Skogvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Skyttervegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Standplassen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Strandvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Strengen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Trollbærveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Åkervegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torsdag uke: 2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,52</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Onsdag uke: &nbsp;</span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>2,6,10,14,18,22,26,30,34,38,42,46,50</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergerfossvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergermotunet</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bjønnputtvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Blåklokkeveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Blålyngstien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fiolveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Furuvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Granvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Grindasvingen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hestehovsbakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hvitveiskroken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Industrivegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kistefossvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Konvallveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kornblomstveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Krokusveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Liljeveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Linneasvingen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Løvetannveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mofivelkroken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Musmyrvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Myrvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Møllevegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nattfiolveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Rensevegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Roseveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Rødkløverstien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Røsslyngveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Samsmoveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sandvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Skogstjerneveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Symreveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tulipanveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fredag uke: 2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,52</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballajse</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torsdag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>2,6,10,14,18,22,26,30,34,38,42,46,50</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bakkelivegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bakkestupveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergerbakkvegen &nbsp; 23, 25, 27, 31, 36-80</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergergata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bergerkneika</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bjerkegata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Brugata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Dampsagveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' valign='bottom' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>E G Borchs gate</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Enggata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fjellheimvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fjordvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Glimtstubben</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Grindavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hønefossvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kirkegata 1-5, 12, &nbsp; 14, 16</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Lidvangvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Moløkkavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Myrbråtaveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nesgata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Ole B. Bergers veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Plassenvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Rundhaugvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Skolebakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Skolevegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Storgata 7, 9, 11-19, 21-34</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torggata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Utsikten</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Vinkelveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Onsdag uke: &nbsp; &nbsp; 1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plasemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fredag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>3,7,11,15,19,23,27,31,35,39,43,47,51</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bekkevegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Elvegata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Feldbergkroken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Forseths veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Gamlevegen 1, 2, 3</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Glassheimvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' valign='bottom' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Glassverkvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Graverengvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Grønlandsvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Grønlivegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hadeland Glassverk</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hermanstien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kirkegata 6, 10</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Krystallen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Lemvigvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Lundsgata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Meieribakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Melkevegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nesgata 1</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nils Bergs veg</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nybrovegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nygaten</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Opperudgata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sagvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Stampeengvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Stensvollvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Storgata 5, 8, 10,&nbsp;12, 20</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Svenåvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Østgata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torsdag uke: &nbsp; &nbsp; &nbsp; 1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fredag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>1,5,9,13,17,21,25,29,33,37,41,45,49</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Betelgata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>Brekkeveien</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Brennasletta</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Brennaveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Brøttetveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Ekornvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Gamlevegen 5-41</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Gaupefaret</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Haravegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Haugergata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Haugsveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hensrudveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hovsbakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hovsmarkveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hovsstubben</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Klinkenbergveien &nbsp; 5, 11</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Lekestien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Midtlivegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>Olumslinna 201,244,288</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Prestlia</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Prestmovegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Rv. 35 (Fra &nbsp; Bekkevegen til Olimb)</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Rådyrvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torshovveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tosobakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tosogata</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tosokroken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Vangskroken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Wangsvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Åslia</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fredag uke: &nbsp; 2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36,38,40,42,44,46,48,50,52</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torsdag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>4,8,12,16,20,24,28,32,36,40,44,48,52</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Engerveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Felbergveien &nbsp; (Felberg ned til Olimb)</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Gml. Rv. 35 (Fra &nbsp; Olimb til Lunner grense)</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Høgnes</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kingeveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Klinkenbergveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' valign='bottom' width='437'>Olumslinna 391,402,430</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' valign='bottom' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Prestensrudvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sagengveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Storetjernsvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Trantjern</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Torsdag uke: &nbsp; &nbsp; &nbsp; 1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mandag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>2,6,10,14,18,22,26,30,34,38,42,46,50</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fjordlinna (Fra &nbsp; Nedre Vang til Bjertnæs)</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Grindvollinna 720 &nbsp; →</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Hagabakken</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sløvika</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sogn</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sognsbakka</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Sognsveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fredag uke: &nbsp; &nbsp; 1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fredag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>4,8,12,16,20,24,28,32,36,40,44,48,52</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Gamleveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Ringeriksvegen &nbsp; (Til delet Ringerike)</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>&nbsp;</td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mat/restavfall</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Mandag uke: &nbsp; &nbsp; 1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51</span></strong></td>
</tr>
<tr style='height: 1cm;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 1cm;' valign='top' width='177'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Papir/plastemballasje</span></strong></td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 1cm;' width='437'><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Tirsdag uke: </span></strong><strong><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>4,8,12,16,20,24,28,32,36,40,44,48,52</span></strong></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bakkavegen 26-370</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Bratvalsvegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fallavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Fundinveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Halvorsebølevegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Kanadavegen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Klokkerengveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Nordengen</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'>Sandvikslandet</td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Snappinveien</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Vestsidevegen (Fra &nbsp; kommunegrense Gran&nbsp;til Bakkavegen)</span></td>
</tr>
<tr style='height: 19.85pt;'>
<td style='padding: 0cm 5.4pt; width: 133pt; height: 19.85pt;' valign='top' width='177'>&nbsp;</td>
<td style='padding: 0cm 5.4pt; width: 327.6pt; height: 19.85pt;' width='437'><span style='color: black; font-family: 'Arial','sans-serif'; font-size: 9pt;'>Østbyveien</span></td>
</tr>
</tbody>
</table> </div></div></article></div>


                        </div>
                                            </div>
                </div>
            </div>

<footer class='art-footer'>
<a title='RSS' class='art-rss-tag-icon' style='position: absolute; bottom: 8px; left: 6px; line-height: 22px; display: none;' href='#'></a><div style='position:relative;padding-left:10px;padding-right:10px'><p>Copyright © 2015. All Rights Reserved Hadeland og Ringerike Avfallsselskap AS.</p></div>
</footer>

    </div>
    <p class='art-page-footer'>
        <span id='art-footnote-links'>Designed by <a href='http://www.webform.no' target='_blank'>WebForm Frank Tverran</a>.</span>
    </p>
</div>



<div id='art-resp'><div id='art-resp-m'></div><div id='art-resp-t'></div></div><div id='art-resp-tablet-landscape'></div><div id='art-resp-tablet-portrait'></div><div id='art-resp-phone-landscape'></div><div id='art-resp-phone-portrait'></div></body>";
            }
        }
    }
}
