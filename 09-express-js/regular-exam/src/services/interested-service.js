import Disaster from "../models/disaster.js";

export async function addInterestedUser(disasterId, userId) {
  await Disaster.findByIdAndUpdate(
    disasterId,
    {
      $addToSet: { interestedList: userId },
      $inc: { interestedCount: 1 },
    },
    { new: true }
  );
}
