INCLUDE Globals.ink
-> main

=== main ===
Please man help us, can you kill the might dragon on the field?
->choices

=== choices ===
    *[No, I can't.]
        ->chosenNo 
    *[Yes, I can.]
        ~ acceptQuest = true
        ->chosenYes

=== chosenYes ===
thank you for chose help us! You have to hit on its head and run from its fire.

->DONE 

=== chosenNo ===
Ok man!

->END
