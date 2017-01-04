using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tommeplan.Repository.TRVPlanRepository;

namespace Tommeplan.Repository.Test
{
    public class TRVMapperTest
    {
        [TestFixture]
        public class ToPlan
        {
            private TRVMapper _mapper;

            [SetUp]
            public void Setup()
            {
                _mapper = new TRVMapper(GetHtmlForBlåklokkevegen());
            }

            [Test]
            public void ReturnererPlanForBlåklokkevegen()
            {
                Assert.NotNull(_mapper.ToPlan());
            }

            [Test]
            [TestCase(2016)]
            [TestCase(2017)]
            public void ReturnererUkerForÅr(int år)
            {
                var plan = _mapper.ToPlan();
                Assert.True(plan.Weeks.Any(x => x.Year == år), "Forventet at {0} skulle finnes", år);
            }

            [Test]
            public void ReturnererMedRestavfallForFørsteUke()
            {
                var plan = _mapper.ToPlan();
                Assert.AreEqual("Restavfall", plan.Weeks.First().Types.First());
            }

            private string GetHtmlForBlåklokkevegen()
            {
                return @"<!DOCTYPE html>
                        <!--[if IE 8]>         <html class='ie ie8 lt-ie8 lt-ie9' lang='no'> <![endif]-->
                        <!--[if IE 9]>         <html class='ie ie9 lt-ie9' lang='no'> <![endif]-->
                        <!--[if gt IE 9]><!-->
                        <html lang='no'>
                        <!--<![endif]-->

                        <head>

                            <meta charset='UTF-8' />
                            <title>Tømmeplan for Blåklokkevegen - Trondheim Renholdsverk</title>
                            <meta name='viewport' content='width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=yes'
                            />



                            <!-- This site is optimized with the Yoast SEO plugin v3.9 - https://yoast.com/wordpress/plugins/seo/ -->
                            <meta name='description' content='Tømmeplan for Blåklokkevegen.' />
                            <meta name='robots' content='noodp' />
                            <meta property='og:locale' content='nb_NO' />
                            <meta property='og:type' content='object' />
                            <meta property='og:title' content='Tømmeplan for Blåklokkevegen - Trondheim Renholdsverk' />
                            <meta property='og:site_name' content='Trondheim Renholdsverk' />
                            <meta name='twitter:card' content='summary' />
                            <meta name='twitter:description' content='Tømmeplan for Blåklokkevegen.' />
                            <meta name='twitter:title' content='Tømmeplan for Blåklokkevegen - Trondheim Renholdsverk' />
                            <!-- / Yoast SEO plugin. -->

                            <link rel='dns-prefetch' href='//s.w.org' />
                            <link rel='stylesheet' id='screen-css' href='http://trv.no/wp-content/themes/trv/frontend/css/min/screen.css' type='text/css'
                                media='all' />
                            <link rel='stylesheet' id='tablepress-default-css' href='http://trv.no/wp-content/plugins/tablepress/css/default.min.css?ver=1.7'
                                type='text/css' media='all' />
                            <script type='text/javascript' src='http://trv.no/wp-includes/js/jquery/jquery.js?ver=1.12.4'></script>
                            <script type='text/javascript' src='http://trv.no/wp-includes/js/jquery/jquery-migrate.min.js?ver=1.4.1'></script>
                            <script type='text/javascript' src='http://trv.no/wp-content/plugins/deviations/js/general.js'></script>
                            <script type='text/javascript' src='http://trv.no/wp-includes/js/underscore.min.js?ver=1.8.3'></script>
                            <script type='text/javascript' src='http://trv.no/wp-content/themes/trv/js/engine.js'></script>
                            <script type='text/javascript' src='http://trv.no/wp-content/plugins/wp-retina-2x/js/picturefill.min.js?ver=3.0.2'></script>
                            <link rel='https://api.w.org/' href='http://trv.no/wp-json/' />

                            <!-- Google Analytics -->
                            <script>
                                (function (i, s, o, g, r, a, m) {
                                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                                    (i[r].q = i[r].q || []).push(arguments)
                                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                                    m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
                                })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

                                ga('create', 'UA-86303276-1', 'auto');
                                ga('send', 'pageview');

                            </script>
                        <link rel='icon' href='http://trv.no/wp-content/uploads/2016/11/cropped-TRV_favicon-32x32.png' sizes='32x32' />
                        <link rel='icon' href='http://trv.no/wp-content/uploads/2016/11/cropped-TRV_favicon-192x192.png' sizes='192x192' />
                        <link rel='apple-touch-icon-precomposed' href='http://trv.no/wp-content/uploads/2016/11/cropped-TRV_favicon-180x180.png'
                        />
                        <meta name='msapplication-TileImage' content='http://trv.no/wp-content/uploads/2016/11/cropped-TRV_favicon-270x270.png' />

                        </head>

                        <body class='location single'>

                            <a class='skip-content screenreader-shortcut' href='#page-content' tabindex='1'>Hopp til hovedinnhold</a><a class='screenreader-shortcut'
                                href='#wasteplan-content' tabindex='1'>Hopp til tømmeplanen</a>
                            <header id='header'>
                                <div class='inner'>

                                    <!-- Logo -->
                                    <a href='http://trv.no/' title='Forsiden - Trondheim Renholdsverk' class='logo'>Trondheim Renholdsverk</a>

                                    <!-- Menu toggle -->
                                    <a id='mobile-menu-toggle' href='#'>Meny</a>
                                    <script>
                                    jQuery(function () {

                                        var secondaryMenu = jQuery('nav.secondary');

                                        /* Secondary menu toggling on small screens */
                                        var toggle = jQuery('#mobile-menu-toggle');
                                        toggle.click(function () {
                                            if (secondaryMenu.is(':visible')) {
                                                secondaryMenu.slideUp();
                                                toggle.removeClass('expanded');
                                                toggle.html('Meny');
                                            } else {
                                                secondaryMenu.slideDown();
                                                toggle.addClass('expanded');
                                                toggle.html('Lukk');
                                            }
                                        });
                                        jQuery(window).resize(_.throttle(function () {
                                            if (secondaryMenu.is(':visible') || secondaryMenu.hasClass('hide-on-tablet-and-above')) return;
                                            if (jQuery(window).width() >= 980) {
                                                secondaryMenu.slideDown(0);
                                            }
                                        }, 200));


                                        /* Secondary menu dropdowns on larger screens */
                                        secondaryMenu.find('.expandable > a').on('mouseover click', function (e) {
                                            e.preventDefault();

                                            if ((jQuery(window).width() < 980) && (e.type == 'mouseover')) return;
                                            if ((jQuery(window).width() >= 980) && (e.type == 'click')) return;

                                            // hide all other modals
                                            jQuery('.modal').hide();

                                            // show the submenu
                                            var item = jQuery(this);
                                            var submenu = item.next();
                                            submenu.show();

                                            // dismiss when hovering outside (delay, to prevent from hiding when we're moving to submenu)
                                            _.each([item, submenu], function (element) {
                                                element.on('mouseout', function (e) {
                                                    _.delay(function () {
                                                        jQuery(this).off('mouseout');
                                                        if (item.is(':hover') || submenu.is(':hover')) return;
                                                        submenu.fadeOut();
                                                    }, 1000);
                                                })
                                            });

                                        });

                                    });		</script>

                        <!-- Main navigation -->
                        <nav class='primary'>
                            <ul>

                                <li class='only-on-tablet-and-above active'><a href='/plan/'><span>Tømmeplan</span></a></li>
                                <li class=''><a href='http://trv.no/produkter-og-tjenester/'><span>Produkter og tjenester</span></a></li>
                                <li class=''><a href='http://trv.no/levere-avfall/'><span>Her leverer du avfall</span></a></li>
                                <li class=''><a href='/sortere/'><span>Slik sorterer du</span></a></li>
                            </ul>
                        </nav>

                        <!-- Secondary navigation -->
                        <nav class='secondary'>
                            <ul>
                                <li class='only-on-tablet-and-above'>
                                    <a href='https://www.facebook.com/trondheim.renholdsverk/' class='icon-facebook-inv' title='Besøk TRV på Facebook'></a>
                                </li>
                                <li class='only-on-tablet-and-above'><a href='tel:91754000' class='icon-phone-inv' title='Kontakt oss på telefon'>917 54 000</a></li>
                                <li class='hide-on-tablet-and-above active'><a href='/plan/'><span>Tømmeplan</span></a></li>
                                <li class=''><a href='http://trv.no/kundesenter/'><span>Kundesenter</span></a></li>
                                <li class=' expandable'><a href='http://trv.no/om-oss/'><span>Om oss</span></a>
                                    <ul class='modal'>
                                        <li class=''><a href='http://trv.no/om-oss/historie/'><span>Historie</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/ansatte/'><span>Ansatte</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/ledige-stillinger/'><span>Ledige stillinger</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/pressekontakt/'><span>Pressekontakt</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/samfunnsansvar/'><span>Samfunnsansvar</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/trvs-strategi/'><span>TRVs strategi</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/regelverk/'><span>Regelverk</span></a></li>
                                        <li class=''><a href='http://trv.no/om-oss/publikasjoner/'><span>Råstoff</span></a></li>
                                    </ul>
                                </li>
                                <li class=' expandable'><a href='/information-in-english/'><span>Other languages</span></a>
                                    <ul class='modal'>
                                        <li class=''><a href='http://trv.no/sorting-tables/information-in-english/'><span>Information in English</span></a></li>
                                        <li
                                            class=''><a href='http://trv.no/sorting-tables/documents-in-other-languages/'><span>Documents in other languages</span></a></li>
                                </ul>
                                </li>
                            </ul>
                        </nav>

                        <!-- Åpningstider -->
                        <div class='openhours'>
                            <strong>Heggstadmoen gjenvinningsstasjon</strong>
                            <div class='openstatus'><span class='closed'>Stengt nå</span></div>
                            <div class='description'>
                                <p>Man-tor   07.00 – 20.00<br /> Fredag     07.00 – 15.00<br /> Lørdag     10.00 – 14.00</p>
                            </div>
                        </div>

                        <!-- Ekstraknapper (kun mobil) -->
                        <div class='shortcuts'>
                            <a href='tel:91754000' class='icon-phone' title='Kontakt oss på telefon'>917 54 000</a>
                            <a href='http://trv.no/kundesenter/' title='Kontakt kundesenteret'>Kundesenter</a>
                        </div>

                        </div>
                        </header>
                        <!-- Main content section -->
                        <div id='page-content' role='main'>
                            <div class='inner'>

                                <div class='wasteplan-search-area collapsed'>

                                    <a href='javascript:jQuery('.wasteplan-search-area').removeClass('collapsed'); jQuery('.searchboxes').slideDown(); jQuery('a.showsearch').hide(); jQuery('.bins.searchbox').focus(); void 0'
                                        class='showsearch' title='Vis søkefelt'>Gjør et nytt søk</a>
                                    <script type='text/javascript'>
                                    jQuery(document).ready(function () { wasteplanSearch.init(); });

                                    var wasteplanSearch = {

                                        inputs: null,
                                        justTabbed: false, // we want to know whether the last keypress was a tab or not	

                                        // initiation
                                        init: function () {
                                            var self = this;

                                            document.addEventListener('keydown', function (e) {
                                                e = e || window.event;
                                                var code = (typeof e.which == 'number') ? e.which : e.keyCode;
                                                self.justTabbed = ((code && !e.metaKey) && (code == 9));
                                            });



                                            // grab our search input box(es)
                                            self.inputs = jQuery('.wasteplan-search-area input.searchbox');
                                            if (!self.inputs.length) return false;

                                            // apply autocomplete and placeholder text for all of them
                                            _.each(self.inputs, function (input) {

                                                var element = jQuery(input);

                                                // get position_id hidden input element (we need it below)
                                                var positionIdEl = element.closest('form').find('input[name=location_id]');

                                                // Enable HTML5 placeholder functionality for non-supporting browsers (defined at the bottom of this file)
                                                element.placeholder();

                                                // turn off default browser autocomplete behaviour (sadly, browser don't seem to properly honor this)
                                                element.attr({ 'autocomplete': 'off', 'autocorrect': 'off' });

                                                // figure out subtype
                                                var subtype = (element.hasClass('bins')) ? 'BINS' : 'CONTAINERS';

                                                // add custom autocomplete (included in engine.js)
                                                // options: https://github.com/devbridge/jQuery-Autocomplete
                                                element.autocomplete({
                                                    paramName: 's',
                                                    serviceUrl: '/wp-json/wasteplan/v1/' + subtype + '/',
                                                    minChars: 2,
                                                    dataType: 'json',
                                                    zIndex: 99,
                                                    appendTo: element.next(),

                                                    transformResult: function (response) {

                                                        return {
                                                            suggestions: jQuery.map(response, function (item) {
                                                                return { value: item.name, data: item.id };
                                                            })
                                                        };
                                                    },

                                                    autoSelectFirst: true,
                                                    triggerSelectOnValidInput: false,

                                                    showNoSuggestionNotice: true,
                                                    noSuggestionNotice: 'Ingen treff.',
                                                    orientation: 'auto',

                                                    // reset positionId when typing
                                                    onInvalidateSelection: function () { positionIdEl.removeAttr('value'); },

                                                    // submit on select
                                                    onSelect: function (suggestion) {

                                                        // store id of select location in hidden data field
                                                        positionIdEl.val(suggestion.data);

                                                        // but make sure we're not selecting when we just tabbed away 
                                                        // (a bit hackish, but it seems to work)
                                                        _.defer(function () {
                                                            if (!self.justTabbed) element.closest('form').trigger('submit');
                                                        });

                                                    },

                                                    ajaxSettings: {
                                                        beforeSend: function () { element.addClass('loading'); },
                                                        complete: function () { element.removeClass('loading');; }
                                                    }

                                                });



                                                /* Make sure form only gets submitted if we have an autocomplete match selected */
                                                element.closest('form').on('submit', function (event) {

                                                    event.preventDefault();

                                                    // do nothing if there's no location_id (we need a match to proceed)
                                                    var location_id = positionIdEl.val();
                                                    if (_.isEmpty(location_id)) return;

                                                    // actually, we're not really submitting the form - we're simply forwarding the user
                                                    // to the correct location for the selected location plan
                                                    location.href = '/plan/' + location_id + '/';

                                                });


                                            });

                                        }

                                    }


                                    /* Wasteplan remember-location */
                                    jQuery(function () {

                                        // if localStorage is unavailable, go no further
                                        if (typeof localStorage == 'undefined') {
                                            checkbox.remove();
                                            return;
                                        }

                                        // get stored location, if any
                                        var storedLocationId = localStorage.getItem('storedLocationId');

                                        // are we on the wasteplan location page?
                                        if (!jQuery('.location.single').length) return;

                                        // have yet to decide on a location (and are we not searching?) ? 

                                        var checkbox = jQuery('.wasteplan .action .remember');
                                        if (!checkbox.length && (location.search.indexOf('&s=') == -1)) {
                                            // redirect to store location
                                            if (storedLocationId) location.href = '/plan/' + storedLocationId + '/';
                                            return;
                                        }

                                        // get location id of current page
                                        var locationId = checkbox.attr('data-location-id');

                                        // if the current location is the stored one, set checkbox
                                        if (locationId == storedLocationId) { checkbox.removeClass('icon-unchecked').addClass('icon-checked'); }

                                        // set or unset stored location Id when clicking
                                        checkbox.click(function () {

                                            // set
                                            if (storedLocationId != locationId) {
                                                storedLocationId = locationId;
                                                localStorage.setItem('storedLocationId', storedLocationId);
                                                checkbox.removeClass('icon-unchecked').removeClass('icon-unchecked');
                                                checkbox.removeClass('icon-unchecked').addClass('icon-checked');
                                            }

                                            // .. or unset
                                            else {
                                                storedLocationId = null;
                                                localStorage.removeItem('storedLocationId');
                                                checkbox.removeClass('icon-unchecked').removeClass('icon-checked');
                                                checkbox.removeClass('icon-unchecked').addClass('icon-unchecked');
                                            }
                                        });

                                    });
                            </script>

                        <h2>Finn din tømmeplan!</h2>

                        <div class='searchboxes' style='display: none;'>

                        <!-- Bins search field -->
                        <div class='bins searchbox-area'>
                            <form action='http://trv.no/plan/'>
                                <input type='hidden' name='type' value='bins' />
                                <input type='hidden' name='location_id' />
                                <label for='bins-searchquery'>Tømmeplan beholdere</label>
                                <input type='text' class='bins searchbox' name='s' id='bins-searchquery' placeholder='Adresse' />
                                <span class='autocomplete-suggestions-area'></span>
                            </form>
                        </div>

                        <!-- Containers search field -->
                        <div class='containers searchbox-area'>
                            <form action='http://trv.no/plan/'>
                                <input type='hidden' name='type' value='containers' />
                                <input type='hidden' name='location_id' />
                                <label for='containers-searchquery'>Tømmeplan containere</label>
                                <input type='text' class='containers searchbox' name='s' id='containers-searchquery' placeholder='Adresse/borettslag' />
                                <span class='autocomplete-suggestions-area'></span>
                            </form>
                        </div>

                        </div>


                        </div>

                        <div class='content' id='wasteplan-content'>

                            <section class='wasteplan'>

                                <header>
                                    <h1 class='subtle'>Tømmeplan for <span>Blåklokkevegen</span><small>beholdere</small></h1>
                                    <div class='actions'>
                                        <div class='action'>
                                            <a class='remember icon-unchecked' data-location-id='108' href='#' title='Automatisk husk hvilken tømmeplan du så på sist'>Husk denne adressen</a>
                                        </div>
                                        <div class='action'>
                                            <a class='print icon-print' href='http://trv.no/pdf/aHR0cDovL3Rydi5uby9wbGFuLzEwOA==' title='Få en utskriftsvennlig versjon av denne tømmeplanen'>Utskriftsvennlig tømmeplan</a>
                                        </div>
                                    </div>
                                </header>



                                <table class='bins'>
                                    <thead>
                                        <tr>
                                            <td class='week'>Uke</td>
                                            <td class='wastetype'>Type avfall</td>
                                            <td class='date'>Dato</td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class='year-2016'>
                                            <td class='week'>51</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>19.12 - 25.12</td>
                                        </tr>
                                        <tr class='year-2016'>
                                            <td class='week'>52</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>26.12 - 01.01</td>
                                        </tr>
                                        <tr class='year-2017 first-of-new-year'>
                                            <td class='week'>1</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>02.01 - 08.01</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>2</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>09.01 - 15.01</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>3</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>16.01 - 22.01</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>4</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>23.01 - 29.01</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>5</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>30.01 - 05.02</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>6</td>
                                            <td class='wastetype plastemballasje'><a href='/sortere/#plastemballasje' title='Les mer om Plastemballasje'>Plastemballasje</a></td>
                                            <td class='date'>06.02 - 12.02</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>7</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>13.02 - 19.02</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>8</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>20.02 - 26.02</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>9</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>27.02 - 05.03</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>10</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>06.03 - 12.03</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>11</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>13.03 - 19.03</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>12</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>20.03 - 26.03</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>13</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>27.03 - 02.04</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>14</td>
                                            <td class='wastetype plastemballasje'><a href='/sortere/#plastemballasje' title='Les mer om Plastemballasje'>Plastemballasje</a></td>
                                            <td class='date'>03.04 - 09.04</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>15</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>10.04 - 16.04</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>16</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>17.04 - 23.04</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>17</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>24.04 - 30.04</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>18</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>01.05 - 07.05</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>19</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>08.05 - 14.05</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>20</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>15.05 - 21.05</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>21</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>22.05 - 28.05</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>22</td>
                                            <td class='wastetype plastemballasje'><a href='/sortere/#plastemballasje' title='Les mer om Plastemballasje'>Plastemballasje</a></td>
                                            <td class='date'>29.05 - 04.06</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>23</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>05.06 - 11.06</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>24</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>12.06 - 18.06</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>25</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>19.06 - 25.06</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>26</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>26.06 - 02.07</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>27</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>03.07 - 09.07</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>28</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>10.07 - 16.07</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>29</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>17.07 - 23.07</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>30</td>
                                            <td class='wastetype plastemballasje'><a href='/sortere/#plastemballasje' title='Les mer om Plastemballasje'>Plastemballasje</a></td>
                                            <td class='date'>24.07 - 30.07</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>31</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>31.07 - 06.08</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>32</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>07.08 - 13.08</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>33</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>14.08 - 20.08</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>34</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>21.08 - 27.08</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>35</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>28.08 - 03.09</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>36</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>04.09 - 10.09</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>37</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>11.09 - 17.09</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>38</td>
                                            <td class='wastetype plastemballasje'><a href='/sortere/#plastemballasje' title='Les mer om Plastemballasje'>Plastemballasje</a></td>
                                            <td class='date'>18.09 - 24.09</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>39</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>25.09 - 01.10</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>40</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>02.10 - 08.10</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>41</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>09.10 - 15.10</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>42</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>16.10 - 22.10</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>43</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>23.10 - 29.10</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>44</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>30.10 - 05.11</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>45</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>06.11 - 12.11</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>46</td>
                                            <td class='wastetype plastemballasje'><a href='/sortere/#plastemballasje' title='Les mer om Plastemballasje'>Plastemballasje</a></td>
                                            <td class='date'>13.11 - 19.11</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>47</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>20.11 - 26.11</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>48</td>
                                            <td class='wastetype papir'><a href='/sortere/#papir' title='Les mer om Papir'>Papir</a></td>
                                            <td class='date'>27.11 - 03.12</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>49</td>
                                            <td class='wastetype restavfall'><a href='/sortere/#restavfall' title='Les mer om Restavfall'>Restavfall</a></td>
                                            <td class='date'>04.12 - 10.12</td>
                                        </tr>
                                        <tr class='year-2017'>
                                            <td class='week'>50</td>
                                            <td class='wastetype tommefri-uke'>Tømmefri uke</td>
                                            <td class='date'>11.12 - 17.12</td>
                                        </tr>
                                    </tbody>
                                </table>


                            </section>

                        </div>


                        </div>
                        </div>
                        <!-- content -->

                        <footer id='footer'>
                            <div class='inner'>


                                <div class='section produkter-og-tjenester'>
                                    <h3>Produkter og tjenester</h3>
                                    <ul>
                                        <li><a href='http://trv.no/produkter-og-tjenester/beholdere/' title='Beholdere'>Beholdere</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/containere/' title='Overflatecontainere'>Overflatecontainere</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/nedgravde-losninger/' title='Nedgravde løsninger'>Nedgravde løsninger</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/avfallstaxi/' title='Avfallstaxi'>Avfallstaxi</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/abonnement-og-priser/' title='Abonnement og priser'>Abonnement og priser</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/varmkompostering/' title='Varmkompostering'>Varmkompostering</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/brukom/' title='BrukOM'>BrukOM</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/hundelatrine/' title='Hundelatrine'>Hundelatrine</a></li>
                                        <li><a href='http://trv.no/produkter-og-tjenester/naeringsavfall/' title='Næringsavfall'>Næringsavfall</a></li>
                                    </ul>
                                </div>
                                <div class='section her-leverer-du-avfall'>
                                    <h3>Her leverer du avfall</h3>
                                    <ul>
                                        <li><a href='http://trv.no/levere-avfall/returpunkt-og-midtbypunkt/' title='Returpunkt og Midtbypunkt'>Returpunkt og Midtbypunkt</a></li>
                                        <li><a href='http://trv.no/levere-avfall/heggstadmoen-gjenvinningsstasjon/' title='Heggstadmoen Gjenvinningsstasjon'>Heggstadmoen Gjenvinningsstasjon</a></li>
                                        <li><a href='http://trv.no/levere-avfall/hageavfallsmottak/' title='Hageavfallsmottak'>Hageavfallsmottak</a></li>
                                    </ul>
                                </div>
                                <div class='section slik-sorterer-du'>
                                    <h3>Slik sorterer du</h3>
                                    <ul>
                                        <li><a href='/sortere/#restavfall'>Restavfall</a></li>
                                        <li><a href='/sortere/#papir'>Papir</a></li>
                                        <li><a href='/sortere/#plastemballasje'>Plastemballasje</a></li>
                                        <li><a href='/sortere/#glassmetall'>Glass- og metallemballasje</a></li>
                                        <li><a href='/sortere/#farlig-avfall'>Farlig avfall</a></li>
                                    </ul>
                                </div>
                                <div class='section site-search'>
                                    <form action='http://trv.no/'>
                                        <label for='sitesearch-s'>Nettsidesøk</label>
                                        <input type='text' name='s' class='searchbox' id='sitesearch-s' placeholder='Søk på nettsiden' />
                                    </form>
                                </div>

                            </div>

                            <div class='sub-footer'>

                                <div class='inner'>

                                    <div class='section info'>
                                        <span>©2016 Trondheim Renholdsverk</span>
                                        <span><a href='http://trv.no/personvern/' class='wordklapp-privacy-link' title='Om personvern og bruk av informasjonskapsler'>Personvern/cookies</a></span>
                                    </div>

                                    <div class='section credits'>
                                        Laget av <a href='http://tibe-t.no' title='Designet av Tibe-T'>Tibe-T</a> og <a href='http://klapp.no' title='Utviklet av Klapp Media'>Klapp Media</a>
                                    </div>
                                </div>

                            </div>



                        </footer>
                        <script>

                                if (typeof gform != 'undefined') {
                                    gform.addFilter('gform_datepicker_options_pre_init', function (optionsObj, formId, fieldId) {
                                        if (formId == 8 && fieldId == 3) {
                                            optionsObj.firstDay = 1;
                                            optionsObj.beforeShowDay = function (date) {

                                                var disabledDays = ['2016-01-01', '2016-05-17', '2016-12-25', '2016-12-26', '2016-03-24', '2016-03-25', '2016-03-27', '2016-03-28', '2016-05-05', '2016-05-15', '2016-05-16', '2017-01-01', '2017-05-17', '2017-12-25', '2017-12-26', '2017-04-13', '2017-04-14', '2017-04-16', '2017-04-17', '2017-05-25', '2017-06-04', '2017-06-05'],
                                                    checkdate = jQuery.datepicker.formatDate('yy-mm-dd', date),
                                                    dow = date.getDay();

                                                return [(disabledDays.indexOf(checkdate) == -1) && (dow != 6) && (dow != 0)];
                                            };
                                            optionsObj.minDate = '+1D';
                                            optionsObj.maxDate = '+6W';

                                        }
                                        return optionsObj;
                                    });
                                }
                            </script>
                        <script type='text/javascript' src='http://trv.no/wp-includes/js/wp-embed.min.js'></script>
                        </body>

                        </html>";
            }
        }
    }
}
