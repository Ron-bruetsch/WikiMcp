using System.Text.Json;
using Server.Tools;
using Server.Tools.Search;
using Server.Wikipedia;

namespace Server.Tests;

public class UnitTest1
{
  [Fact]
  public void Test0()
  {
    var t = SearchTool.Tool().InputSchema;
    Assert.Fail(t.ToString());
  }
  
    [Fact]
    public void Test1()
    {
      string testing =
        """
        {
          "files": [
            {
              "title": "Commons-logo.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Commons-logo.svg",
              "latest": {
                "timestamp": "2016-04-05T22:33:52Z",
                "user": {
                  "id": 161142,
                  "name": "RHaworth"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 446,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/4/4a/Commons-logo.svg/500px-Commons-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 932,
                "width": 1024,
                "height": 1376,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/4/4a/Commons-logo.svg"
              }
            },
            {
              "title": "OOjs UI icon edit-ltr-progressive.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:OOjs_UI_icon_edit-ltr-progressive.svg",
              "latest": {
                "timestamp": "2019-08-21T11:26:11Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 349,
                "width": 20,
                "height": 20,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/8/8a/OOjs_UI_icon_edit-ltr-progressive.svg/20px-OOjs_UI_icon_edit-ltr-progressive.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 349,
                "width": 20,
                "height": 20,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/8/8a/OOjs_UI_icon_edit-ltr-progressive.svg"
              }
            },
            {
              "title": "Semi-protection-shackle.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Semi-protection-shackle.svg",
              "latest": {
                "timestamp": "2019-07-17T13:23:23Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 728,
                "width": 512,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/1/1b/Semi-protection-shackle.svg/960px-Semi-protection-shackle.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 728,
                "width": 512,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/1/1b/Semi-protection-shackle.svg"
              }
            },
            {
              "title": "Symbol category class.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Symbol_category_class.svg",
              "latest": {
                "timestamp": "2021-02-07T15:19:34Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 2923,
                "width": 180,
                "height": 185,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/9/96/Symbol_category_class.svg/250px-Symbol_category_class.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 2923,
                "width": 180,
                "height": 185,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/9/96/Symbol_category_class.svg"
              }
            },
            {
              "title": "Wiktionary-logo-v2.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Wiktionary-logo-v2.svg",
              "latest": {
                "timestamp": "2017-06-13T11:22:43Z",
                "user": {
                  "id": 2584239,
                  "name": "Nemo bis"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 38943,
                "width": 391,
                "height": 391,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/0/06/Wiktionary-logo-v2.svg/500px-Wiktionary-logo-v2.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 38943,
                "width": 391,
                "height": 391,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/0/06/Wiktionary-logo-v2.svg"
              }
            },
            {
              "title": "1919 eclipse positive.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:1919_eclipse_positive.jpg",
              "latest": {
                "timestamp": "2023-07-03T13:47:53Z",
                "user": {
                  "id": 532755,
                  "name": "RCraig09"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 73054,
                "width": 490,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/37/1919_eclipse_positive.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 73054,
                "width": 490,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/37/1919_eclipse_positive.jpg"
              }
            },
            {
              "title": "Crab Nebula.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Crab_Nebula.jpg",
              "latest": {
                "timestamp": "2012-11-25T14:56:04Z",
                "user": {
                  "id": 2355361,
                  "name": "Hawky.diddiz"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 600,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/00/Crab_Nebula.jpg/960px-Crab_Nebula.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 14508851,
                "width": 3864,
                "height": 3864,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/00/Crab_Nebula.jpg"
              }
            },
            {
              "title": "Earth-moon.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Earth-moon.jpg",
              "latest": {
                "timestamp": "2007-09-22T16:57:43Z",
                "user": {
                  "id": 182149,
                  "name": "Panoptik~commonswiki"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 750,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Earth-moon.jpg/960px-Earth-moon.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 995863,
                "width": 3000,
                "height": 2400,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5c/Earth-moon.jpg"
              }
            },
            {
              "title": "Einstein cross.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Einstein_cross.jpg",
              "latest": {
                "timestamp": "2010-12-15T07:39:31Z",
                "user": {
                  "id": 456493,
                  "name": "Tryphon"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 621,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Einstein_cross.jpg/960px-Einstein_cross.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 724001,
                "width": 1915,
                "height": 1849,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/c/c8/Einstein_cross.jpg"
              }
            },
            {
              "title": "Falling ball.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Falling_ball.jpg",
              "latest": {
                "timestamp": "2007-10-20T13:31:34Z",
                "user": {
                  "id": 68946,
                  "name": "MichaelMaggs"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 178,
                "height": 598,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/02/Falling_ball.jpg/250px-Falling_ball.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 371954,
                "width": 819,
                "height": 2751,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/02/Falling_ball.jpg"
              }
            },
            {
              "title": "GalacticRotation2.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:GalacticRotation2.svg",
              "latest": {
                "timestamp": "2023-10-30T20:10:22Z",
                "user": {
                  "id": 1975,
                  "name": "Sebastian Wallroth"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 14448,
                "width": 250,
                "height": 150,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/b/b9/GalacticRotation2.svg/250px-GalacticRotation2.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 14448,
                "width": 250,
                "height": 150,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/b/b9/GalacticRotation2.svg"
              }
            },
            {
              "title": "Gravity action-reaction.gif",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Gravity_action-reaction.gif",
              "latest": {
                "timestamp": "2011-01-25T22:26:56Z",
                "user": {
                  "id": 669755,
                  "name": "Orion 8"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 233669,
                "width": 647,
                "height": 185,
                "duration": 19.6,
                "url": "//upload.wikimedia.org/wikipedia/commons/7/7d/Gravity_action-reaction.gif"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 233669,
                "width": 647,
                "height": 185,
                "duration": 19.6,
                "url": "//upload.wikimedia.org/wikipedia/commons/7/7d/Gravity_action-reaction.gif"
              }
            },
            {
              "title": "He1523a.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:He1523a.jpg",
              "latest": {
                "timestamp": "2012-08-16T08:27:52Z",
                "user": {
                  "id": 33847,
                  "name": "AxelHH"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 43584,
                "width": 180,
                "height": 207,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5f/He1523a.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 43584,
                "width": 180,
                "height": 207,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5f/He1523a.jpg"
              }
            },
            {
              "title": "LIGO Hanford aerial 05.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:LIGO_Hanford_aerial_05.jpg",
              "latest": {
                "timestamp": "2017-09-22T00:38:58Z",
                "user": {
                  "id": 539946,
                  "name": "老陳"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 800,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/a/a6/LIGO_Hanford_aerial_05.jpg/960px-LIGO_Hanford_aerial_05.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 1246133,
                "width": 2400,
                "height": 1600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/a/a6/LIGO_Hanford_aerial_05.jpg"
              }
            },
            {
              "title": "Portrait of Sir Isaac Newton, 1689.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Portrait_of_Sir_Isaac_Newton,_1689.jpg",
              "latest": {
                "timestamp": "2022-01-05T07:10:06Z",
                "user": {
                  "id": 7236875,
                  "name": "Richienb"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 498,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Portrait_of_Sir_Isaac_Newton%2C_1689.jpg/500px-Portrait_of_Sir_Isaac_Newton%2C_1689.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 832580,
                "width": 2218,
                "height": 2671,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/3b/Portrait_of_Sir_Isaac_Newton%2C_1689.jpg"
              }
            },
            {
              "title": "RocketSunIcon.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:RocketSunIcon.svg",
              "latest": {
                "timestamp": "2015-02-27T04:30:31Z",
                "user": {
                  "id": 13899,
                  "name": "AnonMoos"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 3328,
                "width": 128,
                "height": 128,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/RocketSunIcon.svg/250px-RocketSunIcon.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 3328,
                "width": 128,
                "height": 128,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/d/d6/RocketSunIcon.svg"
              }
            },
            {
              "title": "Solar system.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Solar_system.jpg",
              "latest": {
                "timestamp": "2019-02-07T18:19:51Z",
                "user": {
                  "id": 4610879,
                  "name": "Kesäperuna"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 482,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/8/83/Solar_system.jpg/500px-Solar_system.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 4225968,
                "width": 4500,
                "height": 5600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/8/83/Solar_system.jpg"
              }
            },
            {
              "title": "Spacetime lattice analogy white.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Spacetime_lattice_analogy_white.svg",
              "latest": {
                "timestamp": "2026-01-18T04:26:00Z",
                "user": {
                  "id": 12318753,
                  "name": "Obscure2020"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 799,
                "height": 262,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Spacetime_lattice_analogy_white.svg/960px-Spacetime_lattice_analogy_white.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 91388,
                "width": 1680,
                "height": 551,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/b/b8/Spacetime_lattice_analogy_white.svg"
              }
            },
            {
              "title": "Stylised atom with three Bohr model orbits and stylised nucleus.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg",
              "latest": {
                "timestamp": "2020-05-09T21:37:10Z",
                "user": {
                  "id": 6584435,
                  "name": "Mrmw"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 4689,
                "width": 530,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg/960px-Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 4689,
                "width": 530,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/6/6f/Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg"
              }
            },
            {
              "title": "The Leaning Tower of Pisa SB.jpeg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:The_Leaning_Tower_of_Pisa_SB.jpeg",
              "latest": {
                "timestamp": "2015-08-10T15:50:34Z",
                "user": {
                  "id": 7516,
                  "name": "Diliff"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 393,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/6/66/The_Leaning_Tower_of_Pisa_SB.jpeg/500px-The_Leaning_Tower_of_Pisa_SB.jpeg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 2675259,
                "width": 2544,
                "height": 3875,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/6/66/The_Leaning_Tower_of_Pisa_SB.jpeg"
              }
            },
            {
              "title": "UGC 1810 and UGC 1813 in Arp 273 (captured by the Hubble Space Telescope).jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:UGC_1810_and_UGC_1813_in_Arp_273_(captured_by_the_Hubble_Space_Telescope).jpg",
              "latest": {
                "timestamp": "2017-06-14T15:23:42Z",
                "user": {
                  "id": 6171822,
                  "name": "Dokurrat"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 591,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/1/14/UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg/960px-UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 65694560,
                "width": 7887,
                "height": 7994,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/1/14/UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg"
              }
            },
            {
              "title": "Wikibooks-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikibooks-logo.svg",
              "latest": {
                "timestamp": "2009-01-15T17:51:28Z",
                "user": {
                  "id": 91532,
                  "name": "Mike.lifeguard"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 5460,
                "width": 300,
                "height": 300,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Wikibooks-logo.svg/330px-Wikibooks-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 5460,
                "width": 300,
                "height": 300,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/fa/Wikibooks-logo.svg"
              }
            },
            {
              "title": "Wikidata-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikidata-logo.svg",
              "latest": {
                "timestamp": "2014-10-04T19:04:44Z",
                "user": {
                  "id": 57009,
                  "name": "Putnik"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 800,
                "height": 450,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Wikidata-logo.svg/960px-Wikidata-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 621,
                "width": 1050,
                "height": 590,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/ff/Wikidata-logo.svg"
              }
            },
            {
              "title": "Wikiquote-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikiquote-logo.svg",
              "latest": {
                "timestamp": "2006-11-24T17:38:48Z",
                "user": {
                  "id": 22357,
                  "name": "-xfi-"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 1012,
                "width": 300,
                "height": 355,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Wikiquote-logo.svg/330px-Wikiquote-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 1012,
                "width": 300,
                "height": 355,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/fa/Wikiquote-logo.svg"
              }
            },
            {
              "title": "Wikisource-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikisource-logo.svg",
              "latest": {
                "timestamp": "2014-04-10T10:38:55Z",
                "user": {
                  "id": 139275,
                  "name": "ChrisiPK"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 16160,
                "width": 410,
                "height": 430,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Wikisource-logo.svg/500px-Wikisource-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 16160,
                "width": 410,
                "height": 430,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/4/4c/Wikisource-logo.svg"
              }
            },
            {
              "title": "Wikiversity logo 2017.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikiversity_logo_2017.svg",
              "latest": {
                "timestamp": "2017-03-06T10:47:41Z",
                "user": {
                  "id": 113439,
                  "name": "Julian Herzog"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 5411,
                "width": 626,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Wikiversity_logo_2017.svg/960px-Wikiversity_logo_2017.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 5411,
                "width": 626,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/0b/Wikiversity_logo_2017.svg"
              }
            }
          ]
        }
        """;

      var result = JsonSerializer.Deserialize<Paged<MediaFile>>(testing);
    }

    [Fact]
    public void Test2()
    {
      string testing =
        """
        {
          "files": [
            {
              "title": "Commons-logo.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Commons-logo.svg",
              "latest": {
                "timestamp": "2016-04-05T22:33:52Z",
                "user": {
                  "id": 161142,
                  "name": "RHaworth"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 446,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/4/4a/Commons-logo.svg/500px-Commons-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 932,
                "width": 1024,
                "height": 1376,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/4/4a/Commons-logo.svg"
              }
            },
            {
              "title": "OOjs UI icon edit-ltr-progressive.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:OOjs_UI_icon_edit-ltr-progressive.svg",
              "latest": {
                "timestamp": "2019-08-21T11:26:11Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 349,
                "width": 20,
                "height": 20,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/8/8a/OOjs_UI_icon_edit-ltr-progressive.svg/20px-OOjs_UI_icon_edit-ltr-progressive.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 349,
                "width": 20,
                "height": 20,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/8/8a/OOjs_UI_icon_edit-ltr-progressive.svg"
              }
            },
            {
              "title": "Semi-protection-shackle.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Semi-protection-shackle.svg",
              "latest": {
                "timestamp": "2019-07-17T13:23:23Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 728,
                "width": 512,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/1/1b/Semi-protection-shackle.svg/960px-Semi-protection-shackle.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 728,
                "width": 512,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/1/1b/Semi-protection-shackle.svg"
              }
            },
            {
              "title": "Symbol category class.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Symbol_category_class.svg",
              "latest": {
                "timestamp": "2021-02-07T15:19:34Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 2923,
                "width": 180,
                "height": 185,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/9/96/Symbol_category_class.svg/250px-Symbol_category_class.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 2923,
                "width": 180,
                "height": 185,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/9/96/Symbol_category_class.svg"
              }
            },
            {
              "title": "Wiktionary-logo-v2.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Wiktionary-logo-v2.svg",
              "latest": {
                "timestamp": "2017-06-13T11:22:43Z",
                "user": {
                  "id": 2584239,
                  "name": "Nemo bis"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 38943,
                "width": 391,
                "height": 391,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/0/06/Wiktionary-logo-v2.svg/500px-Wiktionary-logo-v2.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 38943,
                "width": 391,
                "height": 391,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/0/06/Wiktionary-logo-v2.svg"
              }
            },
            {
              "title": "1919 eclipse positive.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:1919_eclipse_positive.jpg",
              "latest": {
                "timestamp": "2023-07-03T13:47:53Z",
                "user": {
                  "id": 532755,
                  "name": "RCraig09"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 73054,
                "width": 490,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/37/1919_eclipse_positive.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 73054,
                "width": 490,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/37/1919_eclipse_positive.jpg"
              }
            },
            {
              "title": "Crab Nebula.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Crab_Nebula.jpg",
              "latest": {
                "timestamp": "2012-11-25T14:56:04Z",
                "user": {
                  "id": 2355361,
                  "name": "Hawky.diddiz"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 600,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/00/Crab_Nebula.jpg/960px-Crab_Nebula.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 14508851,
                "width": 3864,
                "height": 3864,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/00/Crab_Nebula.jpg"
              }
            },
            {
              "title": "Earth-moon.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Earth-moon.jpg",
              "latest": {
                "timestamp": "2007-09-22T16:57:43Z",
                "user": {
                  "id": 182149,
                  "name": "Panoptik~commonswiki"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 750,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Earth-moon.jpg/960px-Earth-moon.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 995863,
                "width": 3000,
                "height": 2400,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5c/Earth-moon.jpg"
              }
            },
            {
              "title": "Einstein cross.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Einstein_cross.jpg",
              "latest": {
                "timestamp": "2010-12-15T07:39:31Z",
                "user": {
                  "id": 456493,
                  "name": "Tryphon"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 621,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Einstein_cross.jpg/960px-Einstein_cross.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 724001,
                "width": 1915,
                "height": 1849,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/c/c8/Einstein_cross.jpg"
              }
            },
            {
              "title": "Falling ball.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Falling_ball.jpg",
              "latest": {
                "timestamp": "2007-10-20T13:31:34Z",
                "user": {
                  "id": 68946,
                  "name": "MichaelMaggs"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 178,
                "height": 598,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/02/Falling_ball.jpg/250px-Falling_ball.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 371954,
                "width": 819,
                "height": 2751,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/02/Falling_ball.jpg"
              }
            },
            {
              "title": "GalacticRotation2.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:GalacticRotation2.svg",
              "latest": {
                "timestamp": "2023-10-30T20:10:22Z",
                "user": {
                  "id": 1975,
                  "name": "Sebastian Wallroth"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 14448,
                "width": 250,
                "height": 150,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/b/b9/GalacticRotation2.svg/250px-GalacticRotation2.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 14448,
                "width": 250,
                "height": 150,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/b/b9/GalacticRotation2.svg"
              }
            },
            {
              "title": "Gravity action-reaction.gif",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Gravity_action-reaction.gif",
              "latest": {
                "timestamp": "2011-01-25T22:26:56Z",
                "user": {
                  "id": 669755,
                  "name": "Orion 8"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 233669,
                "width": 647,
                "height": 185,
                "duration": 19.6,
                "url": "//upload.wikimedia.org/wikipedia/commons/7/7d/Gravity_action-reaction.gif"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 233669,
                "width": 647,
                "height": 185,
                "duration": 19.6,
                "url": "//upload.wikimedia.org/wikipedia/commons/7/7d/Gravity_action-reaction.gif"
              }
            },
            {
              "title": "He1523a.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:He1523a.jpg",
              "latest": {
                "timestamp": "2012-08-16T08:27:52Z",
                "user": {
                  "id": 33847,
                  "name": "AxelHH"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 43584,
                "width": 180,
                "height": 207,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5f/He1523a.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 43584,
                "width": 180,
                "height": 207,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5f/He1523a.jpg"
              }
            },
            {
              "title": "LIGO Hanford aerial 05.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:LIGO_Hanford_aerial_05.jpg",
              "latest": {
                "timestamp": "2017-09-22T00:38:58Z",
                "user": {
                  "id": 539946,
                  "name": "老陳"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 800,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/a/a6/LIGO_Hanford_aerial_05.jpg/960px-LIGO_Hanford_aerial_05.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 1246133,
                "width": 2400,
                "height": 1600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/a/a6/LIGO_Hanford_aerial_05.jpg"
              }
            },
            {
              "title": "Portrait of Sir Isaac Newton, 1689.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Portrait_of_Sir_Isaac_Newton,_1689.jpg",
              "latest": {
                "timestamp": "2022-01-05T07:10:06Z",
                "user": {
                  "id": 7236875,
                  "name": "Richienb"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 498,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Portrait_of_Sir_Isaac_Newton%2C_1689.jpg/500px-Portrait_of_Sir_Isaac_Newton%2C_1689.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 832580,
                "width": 2218,
                "height": 2671,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/3b/Portrait_of_Sir_Isaac_Newton%2C_1689.jpg"
              }
            },
            {
              "title": "RocketSunIcon.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:RocketSunIcon.svg",
              "latest": {
                "timestamp": "2015-02-27T04:30:31Z",
                "user": {
                  "id": 13899,
                  "name": "AnonMoos"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 3328,
                "width": 128,
                "height": 128,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/RocketSunIcon.svg/250px-RocketSunIcon.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 3328,
                "width": 128,
                "height": 128,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/d/d6/RocketSunIcon.svg"
              }
            },
            {
              "title": "Solar system.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Solar_system.jpg",
              "latest": {
                "timestamp": "2019-02-07T18:19:51Z",
                "user": {
                  "id": 4610879,
                  "name": "Kesäperuna"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 482,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/8/83/Solar_system.jpg/500px-Solar_system.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 4225968,
                "width": 4500,
                "height": 5600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/8/83/Solar_system.jpg"
              }
            },
            {
              "title": "Spacetime lattice analogy white.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Spacetime_lattice_analogy_white.svg",
              "latest": {
                "timestamp": "2026-01-18T04:26:00Z",
                "user": {
                  "id": 12318753,
                  "name": "Obscure2020"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 799,
                "height": 262,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Spacetime_lattice_analogy_white.svg/960px-Spacetime_lattice_analogy_white.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 91388,
                "width": 1680,
                "height": 551,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/b/b8/Spacetime_lattice_analogy_white.svg"
              }
            },
            {
              "title": "Stylised atom with three Bohr model orbits and stylised nucleus.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg",
              "latest": {
                "timestamp": "2020-05-09T21:37:10Z",
                "user": {
                  "id": 6584435,
                  "name": "Mrmw"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 4689,
                "width": 530,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg/960px-Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 4689,
                "width": 530,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/6/6f/Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg"
              }
            },
            {
              "title": "The Leaning Tower of Pisa SB.jpeg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:The_Leaning_Tower_of_Pisa_SB.jpeg",
              "latest": {
                "timestamp": "2015-08-10T15:50:34Z",
                "user": {
                  "id": 7516,
                  "name": "Diliff"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 393,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/6/66/The_Leaning_Tower_of_Pisa_SB.jpeg/500px-The_Leaning_Tower_of_Pisa_SB.jpeg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 2675259,
                "width": 2544,
                "height": 3875,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/6/66/The_Leaning_Tower_of_Pisa_SB.jpeg"
              }
            },
            {
              "title": "UGC 1810 and UGC 1813 in Arp 273 (captured by the Hubble Space Telescope).jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:UGC_1810_and_UGC_1813_in_Arp_273_(captured_by_the_Hubble_Space_Telescope).jpg",
              "latest": {
                "timestamp": "2017-06-14T15:23:42Z",
                "user": {
                  "id": 6171822,
                  "name": "Dokurrat"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 591,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/1/14/UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg/960px-UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 65694560,
                "width": 7887,
                "height": 7994,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/1/14/UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg"
              }
            },
            {
              "title": "Wikibooks-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikibooks-logo.svg",
              "latest": {
                "timestamp": "2009-01-15T17:51:28Z",
                "user": {
                  "id": 91532,
                  "name": "Mike.lifeguard"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 5460,
                "width": 300,
                "height": 300,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Wikibooks-logo.svg/330px-Wikibooks-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 5460,
                "width": 300,
                "height": 300,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/fa/Wikibooks-logo.svg"
              }
            },
            {
              "title": "Wikidata-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikidata-logo.svg",
              "latest": {
                "timestamp": "2014-10-04T19:04:44Z",
                "user": {
                  "id": 57009,
                  "name": "Putnik"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 800,
                "height": 450,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Wikidata-logo.svg/960px-Wikidata-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 621,
                "width": 1050,
                "height": 590,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/ff/Wikidata-logo.svg"
              }
            },
            {
              "title": "Wikiquote-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikiquote-logo.svg",
              "latest": {
                "timestamp": "2006-11-24T17:38:48Z",
                "user": {
                  "id": 22357,
                  "name": "-xfi-"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 1012,
                "width": 300,
                "height": 355,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Wikiquote-logo.svg/330px-Wikiquote-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 1012,
                "width": 300,
                "height": 355,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/fa/Wikiquote-logo.svg"
              }
            },
            {
              "title": "Wikisource-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikisource-logo.svg",
              "latest": {
                "timestamp": "2014-04-10T10:38:55Z",
                "user": {
                  "id": 139275,
                  "name": "ChrisiPK"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 16160,
                "width": 410,
                "height": 430,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Wikisource-logo.svg/500px-Wikisource-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 16160,
                "width": 410,
                "height": 430,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/4/4c/Wikisource-logo.svg"
              }
            },
            {
              "title": "Wikiversity logo 2017.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikiversity_logo_2017.svg",
              "latest": {
                "timestamp": "2017-03-06T10:47:41Z",
                "user": {
                  "id": 113439,
                  "name": "Julian Herzog"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 5411,
                "width": 626,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Wikiversity_logo_2017.svg/960px-Wikiversity_logo_2017.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 5411,
                "width": 626,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/0b/Wikiversity_logo_2017.svg"
              }
            }
          ]
        }{
          "files": [
            {
              "title": "Commons-logo.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Commons-logo.svg",
              "latest": {
                "timestamp": "2016-04-05T22:33:52Z",
                "user": {
                  "id": 161142,
                  "name": "RHaworth"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 446,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/4/4a/Commons-logo.svg/500px-Commons-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 932,
                "width": 1024,
                "height": 1376,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/4/4a/Commons-logo.svg"
              }
            },
            {
              "title": "OOjs UI icon edit-ltr-progressive.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:OOjs_UI_icon_edit-ltr-progressive.svg",
              "latest": {
                "timestamp": "2019-08-21T11:26:11Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 349,
                "width": 20,
                "height": 20,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/8/8a/OOjs_UI_icon_edit-ltr-progressive.svg/20px-OOjs_UI_icon_edit-ltr-progressive.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 349,
                "width": 20,
                "height": 20,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/8/8a/OOjs_UI_icon_edit-ltr-progressive.svg"
              }
            },
            {
              "title": "Semi-protection-shackle.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Semi-protection-shackle.svg",
              "latest": {
                "timestamp": "2019-07-17T13:23:23Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 728,
                "width": 512,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/1/1b/Semi-protection-shackle.svg/960px-Semi-protection-shackle.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 728,
                "width": 512,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/1/1b/Semi-protection-shackle.svg"
              }
            },
            {
              "title": "Symbol category class.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Symbol_category_class.svg",
              "latest": {
                "timestamp": "2021-02-07T15:19:34Z",
                "user": {
                  "id": 502540,
                  "name": "Xaosflux"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 2923,
                "width": 180,
                "height": 185,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/9/96/Symbol_category_class.svg/250px-Symbol_category_class.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 2923,
                "width": 180,
                "height": 185,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/9/96/Symbol_category_class.svg"
              }
            },
            {
              "title": "Wiktionary-logo-v2.svg",
              "file_description_url": "//en.wikipedia.org/wiki/File:Wiktionary-logo-v2.svg",
              "latest": {
                "timestamp": "2017-06-13T11:22:43Z",
                "user": {
                  "id": 2584239,
                  "name": "Nemo bis"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 38943,
                "width": 391,
                "height": 391,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/thumb/0/06/Wiktionary-logo-v2.svg/500px-Wiktionary-logo-v2.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 38943,
                "width": 391,
                "height": 391,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/en/0/06/Wiktionary-logo-v2.svg"
              }
            },
            {
              "title": "1919 eclipse positive.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:1919_eclipse_positive.jpg",
              "latest": {
                "timestamp": "2023-07-03T13:47:53Z",
                "user": {
                  "id": 532755,
                  "name": "RCraig09"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 73054,
                "width": 490,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/37/1919_eclipse_positive.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 73054,
                "width": 490,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/37/1919_eclipse_positive.jpg"
              }
            },
            {
              "title": "Crab Nebula.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Crab_Nebula.jpg",
              "latest": {
                "timestamp": "2012-11-25T14:56:04Z",
                "user": {
                  "id": 2355361,
                  "name": "Hawky.diddiz"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 600,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/00/Crab_Nebula.jpg/960px-Crab_Nebula.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 14508851,
                "width": 3864,
                "height": 3864,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/00/Crab_Nebula.jpg"
              }
            },
            {
              "title": "Earth-moon.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Earth-moon.jpg",
              "latest": {
                "timestamp": "2007-09-22T16:57:43Z",
                "user": {
                  "id": 182149,
                  "name": "Panoptik~commonswiki"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 750,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Earth-moon.jpg/960px-Earth-moon.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 995863,
                "width": 3000,
                "height": 2400,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5c/Earth-moon.jpg"
              }
            },
            {
              "title": "Einstein cross.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Einstein_cross.jpg",
              "latest": {
                "timestamp": "2010-12-15T07:39:31Z",
                "user": {
                  "id": 456493,
                  "name": "Tryphon"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 621,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Einstein_cross.jpg/960px-Einstein_cross.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 724001,
                "width": 1915,
                "height": 1849,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/c/c8/Einstein_cross.jpg"
              }
            },
            {
              "title": "Falling ball.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Falling_ball.jpg",
              "latest": {
                "timestamp": "2007-10-20T13:31:34Z",
                "user": {
                  "id": 68946,
                  "name": "MichaelMaggs"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 178,
                "height": 598,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/02/Falling_ball.jpg/250px-Falling_ball.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 371954,
                "width": 819,
                "height": 2751,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/02/Falling_ball.jpg"
              }
            },
            {
              "title": "GalacticRotation2.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:GalacticRotation2.svg",
              "latest": {
                "timestamp": "2023-10-30T20:10:22Z",
                "user": {
                  "id": 1975,
                  "name": "Sebastian Wallroth"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 14448,
                "width": 250,
                "height": 150,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/b/b9/GalacticRotation2.svg/250px-GalacticRotation2.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 14448,
                "width": 250,
                "height": 150,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/b/b9/GalacticRotation2.svg"
              }
            },
            {
              "title": "Gravity action-reaction.gif",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Gravity_action-reaction.gif",
              "latest": {
                "timestamp": "2011-01-25T22:26:56Z",
                "user": {
                  "id": 669755,
                  "name": "Orion 8"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 233669,
                "width": 647,
                "height": 185,
                "duration": 19.6,
                "url": "//upload.wikimedia.org/wikipedia/commons/7/7d/Gravity_action-reaction.gif"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 233669,
                "width": 647,
                "height": 185,
                "duration": 19.6,
                "url": "//upload.wikimedia.org/wikipedia/commons/7/7d/Gravity_action-reaction.gif"
              }
            },
            {
              "title": "He1523a.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:He1523a.jpg",
              "latest": {
                "timestamp": "2012-08-16T08:27:52Z",
                "user": {
                  "id": 33847,
                  "name": "AxelHH"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": 43584,
                "width": 180,
                "height": 207,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5f/He1523a.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 43584,
                "width": 180,
                "height": 207,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/5/5f/He1523a.jpg"
              }
            },
            {
              "title": "LIGO Hanford aerial 05.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:LIGO_Hanford_aerial_05.jpg",
              "latest": {
                "timestamp": "2017-09-22T00:38:58Z",
                "user": {
                  "id": 539946,
                  "name": "老陳"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 800,
                "height": 533,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/a/a6/LIGO_Hanford_aerial_05.jpg/960px-LIGO_Hanford_aerial_05.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 1246133,
                "width": 2400,
                "height": 1600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/a/a6/LIGO_Hanford_aerial_05.jpg"
              }
            },
            {
              "title": "Portrait of Sir Isaac Newton, 1689.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Portrait_of_Sir_Isaac_Newton,_1689.jpg",
              "latest": {
                "timestamp": "2022-01-05T07:10:06Z",
                "user": {
                  "id": 7236875,
                  "name": "Richienb"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 498,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Portrait_of_Sir_Isaac_Newton%2C_1689.jpg/500px-Portrait_of_Sir_Isaac_Newton%2C_1689.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 832580,
                "width": 2218,
                "height": 2671,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/3/3b/Portrait_of_Sir_Isaac_Newton%2C_1689.jpg"
              }
            },
            {
              "title": "RocketSunIcon.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:RocketSunIcon.svg",
              "latest": {
                "timestamp": "2015-02-27T04:30:31Z",
                "user": {
                  "id": 13899,
                  "name": "AnonMoos"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 3328,
                "width": 128,
                "height": 128,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/d/d6/RocketSunIcon.svg/250px-RocketSunIcon.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 3328,
                "width": 128,
                "height": 128,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/d/d6/RocketSunIcon.svg"
              }
            },
            {
              "title": "Solar system.jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Solar_system.jpg",
              "latest": {
                "timestamp": "2019-02-07T18:19:51Z",
                "user": {
                  "id": 4610879,
                  "name": "Kesäperuna"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 482,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/8/83/Solar_system.jpg/500px-Solar_system.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 4225968,
                "width": 4500,
                "height": 5600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/8/83/Solar_system.jpg"
              }
            },
            {
              "title": "Spacetime lattice analogy white.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Spacetime_lattice_analogy_white.svg",
              "latest": {
                "timestamp": "2026-01-18T04:26:00Z",
                "user": {
                  "id": 12318753,
                  "name": "Obscure2020"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 799,
                "height": 262,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/b/b8/Spacetime_lattice_analogy_white.svg/960px-Spacetime_lattice_analogy_white.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 91388,
                "width": 1680,
                "height": 551,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/b/b8/Spacetime_lattice_analogy_white.svg"
              }
            },
            {
              "title": "Stylised atom with three Bohr model orbits and stylised nucleus.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg",
              "latest": {
                "timestamp": "2020-05-09T21:37:10Z",
                "user": {
                  "id": 6584435,
                  "name": "Mrmw"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 4689,
                "width": 530,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/6/6f/Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg/960px-Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 4689,
                "width": 530,
                "height": 600,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/6/6f/Stylised_atom_with_three_Bohr_model_orbits_and_stylised_nucleus.svg"
              }
            },
            {
              "title": "The Leaning Tower of Pisa SB.jpeg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:The_Leaning_Tower_of_Pisa_SB.jpeg",
              "latest": {
                "timestamp": "2015-08-10T15:50:34Z",
                "user": {
                  "id": 7516,
                  "name": "Diliff"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 393,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/6/66/The_Leaning_Tower_of_Pisa_SB.jpeg/500px-The_Leaning_Tower_of_Pisa_SB.jpeg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 2675259,
                "width": 2544,
                "height": 3875,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/6/66/The_Leaning_Tower_of_Pisa_SB.jpeg"
              }
            },
            {
              "title": "UGC 1810 and UGC 1813 in Arp 273 (captured by the Hubble Space Telescope).jpg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:UGC_1810_and_UGC_1813_in_Arp_273_(captured_by_the_Hubble_Space_Telescope).jpg",
              "latest": {
                "timestamp": "2017-06-14T15:23:42Z",
                "user": {
                  "id": 6171822,
                  "name": "Dokurrat"
                }
              },
              "preferred": {
                "mediatype": "BITMAP",
                "size": null,
                "width": 591,
                "height": 599,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/1/14/UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg/960px-UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg"
              },
              "original": {
                "mediatype": "BITMAP",
                "size": 65694560,
                "width": 7887,
                "height": 7994,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/1/14/UGC_1810_and_UGC_1813_in_Arp_273_%28captured_by_the_Hubble_Space_Telescope%29.jpg"
              }
            },
            {
              "title": "Wikibooks-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikibooks-logo.svg",
              "latest": {
                "timestamp": "2009-01-15T17:51:28Z",
                "user": {
                  "id": 91532,
                  "name": "Mike.lifeguard"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 5460,
                "width": 300,
                "height": 300,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Wikibooks-logo.svg/330px-Wikibooks-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 5460,
                "width": 300,
                "height": 300,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/fa/Wikibooks-logo.svg"
              }
            },
            {
              "title": "Wikidata-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikidata-logo.svg",
              "latest": {
                "timestamp": "2014-10-04T19:04:44Z",
                "user": {
                  "id": 57009,
                  "name": "Putnik"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": null,
                "width": 800,
                "height": 450,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/ff/Wikidata-logo.svg/960px-Wikidata-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 621,
                "width": 1050,
                "height": 590,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/ff/Wikidata-logo.svg"
              }
            },
            {
              "title": "Wikiquote-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikiquote-logo.svg",
              "latest": {
                "timestamp": "2006-11-24T17:38:48Z",
                "user": {
                  "id": 22357,
                  "name": "-xfi-"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 1012,
                "width": 300,
                "height": 355,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Wikiquote-logo.svg/330px-Wikiquote-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 1012,
                "width": 300,
                "height": 355,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/f/fa/Wikiquote-logo.svg"
              }
            },
            {
              "title": "Wikisource-logo.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikisource-logo.svg",
              "latest": {
                "timestamp": "2014-04-10T10:38:55Z",
                "user": {
                  "id": 139275,
                  "name": "ChrisiPK"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 16160,
                "width": 410,
                "height": 430,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Wikisource-logo.svg/500px-Wikisource-logo.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 16160,
                "width": 410,
                "height": 430,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/4/4c/Wikisource-logo.svg"
              }
            },
            {
              "title": "Wikiversity logo 2017.svg",
              "file_description_url": "https://commons.wikimedia.org/wiki/File:Wikiversity_logo_2017.svg",
              "latest": {
                "timestamp": "2017-03-06T10:47:41Z",
                "user": {
                  "id": 113439,
                  "name": "Julian Herzog"
                }
              },
              "preferred": {
                "mediatype": "DRAWING",
                "size": 5411,
                "width": 626,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Wikiversity_logo_2017.svg/960px-Wikiversity_logo_2017.svg.png"
              },
              "original": {
                "mediatype": "DRAWING",
                "size": 5411,
                "width": 626,
                "height": 512,
                "duration": null,
                "url": "//upload.wikimedia.org/wikipedia/commons/0/0b/Wikiversity_logo_2017.svg"
              }
            }
          ]
        }
        """;

      var result = JsonSerializer.Deserialize<Paged<MediaFile>>(testing);
    }
}