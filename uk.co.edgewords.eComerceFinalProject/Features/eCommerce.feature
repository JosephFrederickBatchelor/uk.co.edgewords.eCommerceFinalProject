Feature: eCommerce

Background: Logging into the eCommerce site
	Given I can log into the eCommerce site with 'joseph.batchelor@nFocus.co.uk' and 'nFocus123'

@tag1
Scenario: Purchasing an item with a discount code
	Given that I am logged in to the ecommerce site
	When I purchase a 'Belt' with the discount code 'edgewords'
	Then the correct cost is displayed with a '15' percent discount
	When I have finished checking out
	Then the order number displayed is the same as the one in my orders
