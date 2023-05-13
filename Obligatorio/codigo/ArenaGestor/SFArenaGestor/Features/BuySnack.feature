Feature: BuySnack

@BuyTicketWithoutSnacks
Scenario: Buy a ticket with no snacks
	Given a concert with available tickets
    And a signed in spectator user
    When the user confirms the purchase
    Then the message code should be "200"

@BuyTicketWithSnacks
Scenario: Buy a ticket with snacks
	Given a concert with available tickets
    And a signed in spectator user
    And the user selected a snack to purchase with name "NewSnack", description "Desription", price "1" and amount "1"
    When the user confirms the purchase
    Then the message code should be "200"

@ForbiddenSnackBuy
Scenario: Buy a ticket with an invalid user
    Given a concert with available tickets
    And a signed in non spectator user
    When the user confirms the purchase
    Then the message code should be "403"