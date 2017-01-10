##Hello Gilded Rose team :)

First of all, thank you for the heads up regarding the golbin sitting at the corner. I know you mentioned that none of his code should not be changed but none the less I felt there was room for improvement.
Upon feeling so, I decided to try and have conversation with him. I took your warnings very seriously, so I contacted local wizard who is an old acquaintance of mine. He let me borrow his cloak of charisma +3 and also get me 2 spell scrolls. One was a Charm person and the second a Charm monster as I believe in some places it is still debatable whether a goblin is considered a person or a monster :)

One evening then I decided to wear the magic cloak and cast both spells just in case. I approached the angry goblin decided to start the conversation. During this time, we had a talk about the certain parts of the code that belong to him and I came with a few arguments as to why it might be better if we changed it “a bit”.  These arguments included from simple things as for example that it is not the best practice to keep data hardcoded in the source code, or that have the data stored in the main project it could cause a circular dependency on some scenarios.

After seeing that the goblin was positive to listen to these, I also felt confident enough to point out that code sharing and being open to new ideas is not as bad as it seems. No one is perfect or all knowing, so being able to share and discuss changes our code will eventually lead us on the way of becoming better developers.

The result was that we decided to create a small database for storing the data for the inn even though we would have to add an Id to the Item class. He was still not acceptant to the idea of adding for example an ItemType enumerator so we compromised in adding an extra table that would hold item attributes instead, thus affecting the Item object as little as possible.
You can find the scripts for the tables in the InnAdministrator.Data project. You will just need to create a new SQL Server database named "InnAdministrator" in any of your systems, change the connection string in the Console project config file and run the scripts for the table and data on the database.

I then changed the structure to work with a “bit” more SOLID principles in order to make the application more extensible, since I heard there is a great interest from other inns in the area and we might be able to license it to some of them as well. 
I also added a small set of unit tests during the process. Please note that I have included some tests that run both as [Fact]s and as [Theory] just as an example, for Aged cheese and backstage passes.

I thought of splitting parts of the application to a web client and web service but I decided to leave this until we had a chance to talk together.

For any questions you might have please feel free to contact me.

Thank you for your time! It was quite interesting to see how it would work out with mr. goblin :)
