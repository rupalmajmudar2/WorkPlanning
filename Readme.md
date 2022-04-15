Work Planning Application
Rupal Majmudar April 2022

Project thoughts n tasks are in https://github.com/users/rupalmajmudar2/projects/1
- You need .NetCore5.0 installed along with NUNits [NuGets NUnit, NUnit3TestAdapter & Microsoft.NET.Test.Sdk]
- Look at the master branch (not main!)

(i) git clone https://github.com/rupalmajmudar2/WorkPlanning.git
(ii) git checkout master
(iii) dotnet test --filter "FullyQualifiedName=RmWorkPlanningNUnits.WorkPlanTests"
(iv) Tests from Postman:
	GET https://localhost:5001/WorkPlan/workers
	POST https://localhost:5001/WorkPlan/createWorker/alice  -> id=1511627
	POST https://localhost:5001/WorkPlan/createWorker/bob  -> id=1392333
	POST https://localhost:5001/WorkPlan/AddShift/1/1392333

