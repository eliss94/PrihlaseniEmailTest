Feature: EmailTest
	Test prihlaseni do emailu na seznamu 

@mytag
Scenario: Prihlaseni do emailu 
	Given jsem na webu seznam.cz
	When jako jmeno zadam <jmeno> 
	When jako heslo zadam <heslo>
	When jako domenu zadam <domena>
	When kliknu na prihlasit
	Then bych mel byt na strance mailu
	Then zavru prohlizec

	Examples: 
	| jmeno     | heslo   | domena   |
	| example11 | PpFf123 | email.cz |

Scenario: Spatne prihlaseni do emailu
	Given jsem na webu seznam.cz
	When jako jmeno zadam <jmeno>
	When jako domenu zadam <domena>
	When jako heslo zadam <heslo>
	When kliknu na prihlasit
	Then bych mel byt na strance neuspesne prihlaseni
	Then zavru prohlizec
	
	Examples: 
	| jmeno  | domena    |heslo    |
	|        | seznam.cz |jouza356 |
	| walter | email.cz  |         |

