Feature: EmailTest
	Test prihlaseni do emailu na seznamu 

@mytag
Scenario: Prihlaseni do emailu 
	Given jsem na webu seznam.cz
	Then jako jmeno zadam <jmeno> 
	Then jako heslo zadam <heslo>
	Then jako domenu zadam <domena>
	Then kliknu na prihlasit
	Then zkontroluji uspesnost prihlaseni
	Then zavru prohlizec

	Examples: 
	| jmeno     | heslo   | domena   |
	| example11 | PpFf123 | email.cz |

Scenario: Spatne prihlaseni do emailu
	Given jsem na webu seznam.cz
	Then jako jmeno zadam <jmeno>
	Then jako domenu zadam <domena>
	Then jako heslo zadam <heslo>
	Then kliknu na prihlasit
	Then zkontroluji neuspesnost prihlaseni
	Then zavru prohlizec
	
	Examples: 
	| jmeno  | domena    |heslo    |
	|        | seznam.cz |jouza356 |
	| walter | email.cz  |         |

