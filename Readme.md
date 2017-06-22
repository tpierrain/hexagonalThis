## HexagonalThis Revisited

This kata is based on [hexagonalThis](https://github.com/tpierrain/hexagonalThis)
A kata by [Thomas PIERRAIN](https://github.com/tpierrain) 
Prepared and live coded with [Alistair Cockburn](http://alistair.cockburn.us/)
About [Hexagonal Architecture](http://alistair.cockburn.us/Hexagonal+architecture)

I've only (re)scripted the kata following what has been done in the meetup [Alistair in the 'hexagon'](https://www.meetup.com/fr-FR/DDD-Paris/events/240715351/) in order to make a live-coding session with my colleagues.

__Hexagon__

1. Create an acceptance test:

	*Should_give_Verses_when_asked_for_Poetry*

2. The test instantiate the hexagon that returns a hardcoded poem:

		"I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)"

3. Identify:

  * The hexagon
  * The left-side port
  * The left-side adapter

__Going out from the hexagon (but not really)__

1. Create an acceptance test:
	
	*Should_give_verses_when_asked_for_Poetry_with_the_support_of_a_PoetryLibrary*

2. The test mock the right-side port that returns this poem:

		"If you could read a leaf or tree\r\nyou'd have no need of books.\r\n-- Alistair Cockburn (1987)"

3. Make the hexagon expose the right side port. The hexagon returns now what the right-side port provides

4. Identify:	
	
  * The left-side port
  * The left-side adapter
  * The hexagon
  * The right-side port
  * The right-side adapter

__Going in to the hexagon (but not really)__

1. Create an acceptance test:
	
	*Should_provides_verses_when_asked_for_Poetry_through_a_ConsoleAdaper*

2. The test should:
	
  * Instantiate the right-side adapter(s) that returns:

		"If you could read a leaf or tree\r\nyou'd have no need of books.\r\n-- Alistair Cockburn (1987)"

  * Instantiate the hexagon

  * Instantiate the left-side adapter(s) that throw out the hexagon this:

		"Poem:\nIf you could read a leaf or tree\r\nyou'd have no need of books.\r\n-- Alistair Cockburn (1987)"

3. Identify:

  * The left-side port
  * The left-side adapter
  * The hexagon
  * The right-side port
  * The right-side adapter

__Going in the hexagon (for real)__

1. Creates a console program that implements the ConsoleAdapter.

__Going out the hexagon (for real)__

1. Create an acceptance test:

	*Should_gives_Verses_when_asked_for_Poetry_with_the_support_of_a_FileAdapter*

2. The test should:
	
  * Instantiate a file adapter which takes a file path and returns the poem in the file:

		"Comme je descendais des Fleuves impassibles,\r\nJe ne me sentis plus guidé par les haleurs :\r\nDes Peaux-Rouges criards les avaient pris pour cibles,\r\nLes ayant cloués nus aux poteaux de couleurs.\r\n\r\nJ'étais insoucieux de tous les équipages,\r\nPorteur de blés flamands ou de cotons anglais.\r\nQuand avec mes haleurs ont fini ces tapages,\r\nLes Fleuves m'ont laissé descendre où je voulais.\r\n\r\nDans les clapotements furieux des marées,\r\nMoi, l'autre hiver, plus sourd que les cerveaux d'enfants,\r\nJe courus ! Et les Péninsules démarrées\r\nN'ont pas subi tohu-bohus plus triomphants.\r\n\r\nLa tempête a béni mes éveils maritimes.\r\nPlus léger qu'un bouchon j'ai dansé sur les flots\r\nQu'on appelle rouleurs éternels de victimes,\r\nDix nuits, sans regretter l'oeil niais des falots !\r\n\r\nPlus douce qu'aux enfants la chair des pommes sûres,\r\nL'eau verte pénétra ma coque de sapin\r\nEt des taches de vins bleus et des vomissures\r\nMe lava, dispersant gouvernail et grappin.\r\n\r\nEt dès lors, je me suis baigné dans le Poème\r\nDe la Mer, infusé d'astres, et lactescent,\r\nDévorant les azurs verts ; où, flottaison blême\r\nEt ravie, un noyé pensif parfois descend ;\r\n\r\nOù, teignant tout à coup les bleuités, délires\r\nEt rhythmes lents sous les rutilements du jour,\r\nPlus fortes que l'alcool, plus vastes que nos lyres,\r\nFermentent les rousseurs amères de l'amour !\r\n\r\nJe sais les cieux crevant en éclairs, et les trombes\r\nEt les ressacs et les courants : je sais le soir,\r\nL'Aube exaltée ainsi qu'un peuple de colombes,\r\nEt j'ai vu quelquefois ce que l'homme a cru voir !\r\n\r\nJ'ai vu le soleil bas, taché d'horreurs mystiques,\r\nIlluminant de longs figements violets,\r\nPareils à des acteurs de drames très antiques\r\nLes flots roulant au loin leurs frissons de volets !\r\n\r\nJ'ai rêvé la nuit verte aux neiges éblouies,\r\nBaiser montant aux yeux des mers avec lenteurs,\r\nLa circulation des sèves inouïes,\r\nEt l'éveil jaune et bleu des phosphores chanteurs !\r\n\r\nJ'ai suivi, des mois pleins, pareille aux vacheries\r\nHystériques, la houle à l'assaut des récifs,\r\nSans songer que les pieds lumineux des Maries\r\nPussent forcer le mufle aux Océans poussifs !\r\n\r\nJ'ai heurté, savez-vous, d'incroyables Florides\r\nMêlant aux fleurs des yeux de panthères à peaux\r\nD'hommes ! Des arcs-en-ciel tendus comme des brides\r\nSous l'horizon des mers, à de glauques troupeaux !\r\n\r\nJ'ai vu fermenter les marais énormes, nasses\r\nOù pourrit dans les joncs tout un Léviathan !\r\nDes écroulements d'eaux au milieu des bonaces,\r\nEt les lointains vers les gouffres cataractant !\r\n\r\nGlaciers, soleils d'argent, flots nacreux, cieux de braises !\r\nÉchouages hideux au fond des golfes bruns\r\nOù les serpents géants dévorés des punaises\r\nChoient, des arbres tordus, avec de noirs parfums !\r\n\r\nJ'aurais voulu montrer aux enfants ces dorades\r\nDu flot bleu, ces poissons d'or, ces poissons chantants.\r\n- Des écumes de fleurs ont bercé mes dérades\r\nEt d'ineffables vents m'ont ailé par instants.\r\n\r\nParfois, martyr lassé des pôles et des zones,\r\nLa mer dont le sanglot faisait mon roulis doux\r\nMontait vers moi ses fleurs d'ombre aux ventouses jaunes\r\nEt je restais, ainsi qu'une femme à genoux...\r\n\r\nPresque île, ballottant sur mes bords les querelles\r\nEt les fientes d'oiseaux clabaudeurs aux yeux blonds.\r\nEt je voguais, lorsqu'à travers mes liens frêles\r\nDes noyés descendaient dormir, à reculons !\r\n\r\nOr moi, bateau perdu sous les cheveux des anses,\r\nJeté par l'ouragan dans l'éther sans oiseau,\r\nMoi dont les Monitors et les voiliers des Hanses\r\nN'auraient pas repêché la carcasse ivre d'eau ;\r\n\r\nLibre, fumant, monté de brumes violettes,\r\nMoi qui trouais le ciel rougeoyant comme un mur\r\nQui porte, confiture exquise aux bons poètes,\r\nDes lichens de soleil et des morves d'azur ;\r\n\r\nQui courais, taché de lunules électriques,\r\nPlanche folle, escorté des hippocampes noirs,\r\nQuand les juillets faisaient crouler à coups de triques\r\nLes cieux ultramarins aux ardents entonnoirs ;\r\n\r\nMoi qui tremblais, sentant geindre à cinquante lieues\r\nLe rut des Béhémots et les Maelstroms épais,\r\nFileur éternel des immobilités bleues,\r\nJe regrette l'Europe aux anciens parapets !\r\n\r\nJ'ai vu des archipels sidéraux ! et des îles\r\nDont les cieux délirants sont ouverts au vogueur :\r\n- Est-ce en ces nuits sans fonds que tu dors et t'exiles,\r\nMillion d'oiseaux d'or, ô future Vigueur ?\r\n\r\nMais, vrai, j'ai trop pleuré ! Les Aubes sont navrantes.\r\nToute lune est atroce et tout soleil amer :\r\nL'âcre amour m'a gonflé de torpeurs enivrantes.\r\nÔ que ma quille éclate ! Ô que j'aille à la mer !\r\n\r\nSi je désire une eau d'Europe, c'est la flache\r\nNoire et froide où vers le crépuscule embaumé\r\nUn enfant accroupi plein de tristesse, lâche\r\nUn bateau frêle comme un papillon de mai.\r\n\r\nJe ne puis plus, baigné de vos langueurs, ô lames,\r\nEnlever leur sillage aux porteurs de cotons,\r\nNi traverser l'orgueil des drapeaux et des flammes,\r\nNi nager sous les yeux horribles des pontons.\r\n-- Arthur Rimbaud (1883)"

  * Improves the hexagon to support a file adapter

3. Identify:
 
  * The left-side port
  * The left-side adapter
  * The hexagon
  * The right-side port
  * The right-side adapter
