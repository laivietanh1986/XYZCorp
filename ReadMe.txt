What I have done :
      1.remove all formatter except Json => so that user must send request  header with content-type = application/json. and the result will always format with json media type. 
      2.config helper page  so that API description will display in helper page . (could improve later with swagger package , now agree with Microsoft solution ) .
      3.write unit test for all method in service .
      4. store data as static list in memory so that you will be easy to test . 
*Need to improve :
      1. separate  layer of the API (Project structure )
      2. user dependency injection 
      3. user database to store data .
      4. Write more test case about validate input . 

I also did this project in Visual studio 2017 and target framework is 4.6 .
 
