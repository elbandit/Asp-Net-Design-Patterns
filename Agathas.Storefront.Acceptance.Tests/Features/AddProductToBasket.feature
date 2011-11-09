Feature: Add Products to a Basket
	In order to purchase products
    As a customer
    I want to be able to add products to my basket

Scenario: Add product to a Basket
	Given I'm on a product detail page
	And I have no products in my basket
	When I click the add product button				
	Then I should see a total of  items in my basket

	
