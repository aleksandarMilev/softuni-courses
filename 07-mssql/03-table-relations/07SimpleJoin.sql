select MountainRange,
	PeakName,
	Elevation
from Peaks p
join Mountains m
on m.Id = p.MountainId
where m.MountainRange = 'Rila'
order by p.Elevation desc;
