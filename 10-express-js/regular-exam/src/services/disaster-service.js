import Disaster from "../models/disaster.js";

export async function all() {
  return await Disaster.find({}).select("_id name location type image").lean();
}

export async function search(name, type) {
  const filter = {};

  if (name) {
    filter.name = { $regex: new RegExp(name, "i") };
  }

  if (type) {
    filter.type = type;
  }

  return await Disaster.find(filter)
    .select("_id name location type image")
    .lean();
}

export async function byId(id) {
  return await Disaster.findById(id)
    .select(
      "_id name location type image year description owner interestedList"
    )
    .lean();
}

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

export async function create(data, userId) {
  await Disaster.create({ ...data, owner: userId });
}

export async function update(disasterId, data) {
  const disaster = await Disaster.findById(disasterId);

  if (disaster) {
    Object.assign(disaster, data);
    await disaster.validate();

    return await disaster.save();
  }
}

export async function remove(disasterId, userId) {
  const disaster = await Disaster.findById(disasterId);

  if (disaster && disaster.owner.toString() === userId) {
    await Disaster.findByIdAndDelete(disasterId);
  }
}
