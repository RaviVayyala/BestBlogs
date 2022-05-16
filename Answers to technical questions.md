 # Answers to technical questions
 
 ### 1. Spent around 3 hours on this JustEat coding test. Given more time I would have created application which accepts logging, User Interface, more validations, Custom Exception handling.
 
 ### 2. Architected the project in a very simple and clear manner, the solution has a different projects i.e., Console project, Core business, and Unit Tests. Project is developed using .net core and the best coding practices like Dependency injection, SOLID principles, Custom exceptions, Unit tests were written and it is Platform independent. Sample output and unit tests screen shots attached below.
  ![image](https://user-images.githubusercontent.com/42008857/168655205-7bfd2f1b-58b6-4ff7-965d-bddfd8665c3d.png)
 ![image](https://user-images.githubusercontent.com/42008857/168654615-23c2e2d3-a03f-49b7-9a1a-b1d7396a30cc.png)

### 3. Performance issues can be tracked down in multple ways, There are some specific performance monitoring tools that can be used to track performance. In one of my pervious company we introduced some script in to the code for App Dynamics, Which is used to see the performance of the website. We can also use .Net profilers and traces for tracking performance.
  #### I have used the below tools to track the performance.
  1. Windows logs or Web Server (IIS) Access Logs
  2. Exception Tracking 
  3. logging framework
  4. SQL profiler

### 4. My immediate thought after seeing the JustEat API response is it was too big, I believe it is not required to send the response that big in a single go, We can simplify/optimize it by splitting it into multiple parts like intially sending only the basic information like Restaurants name, logos and some important info and if the user needed more info then we can send more info like cuisine type and all the remaining details (we can retrieve it on demand). 
 
