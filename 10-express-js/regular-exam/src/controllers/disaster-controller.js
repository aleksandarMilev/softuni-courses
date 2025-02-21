import { Router } from "express";

import { isAuth } from "../middlewares/auth-middleware.js";
import { getErrorMessage } from "../common/functions.js";
import * as service from "../services/disaster-service.js";

const controller = Router();

controller.get("/", async (req, res) => {
  try {
    const disasters = await service.all();
    res.render("disaster/catalog", { disasters: disasters });
  } catch (error) {
    res.render("disaster/catalog", {
      error: getErrorMessage(error),
      disasters: [],
    });
  }
});

controller.get("/search", async (req, res) => {
  const { name, type } = req.query;

  try {
    const disasters = await service.search(name, type);
    res.render("disaster/search", { disasters, name, type });
  } catch (error) {
    res.render("disaster/search", {
      error: getErrorMessage(error),
      disasters: [],
    });
  }
});

controller.get("/:id/details", async (req, res) => {
  const disasterId = req.params.id;
  const userId = req.user?.id;

  try {
    const disaster = await service.byId(disasterId);
    const isInterested =
      userId &&
      disaster.interestedList.some(
        (interestId) => interestId.toString() === userId
      );

    res.render("disaster/details", {
      disaster: disaster,
      isGuest: userId === undefined,
      isCreator: userId === disaster.owner.toString(),
      isInterested: isInterested,
    });
  } catch (error) {
    res.render("disaster/details", {
      disaster: null,
    });
  }
});

controller.get("/create", isAuth, (req, res) => {
  res.render("disaster/create");
});

controller.post("/create", isAuth, async (req, res) => {
  const data = req.body;
  const userId = req.user.id;

  try {
    await service.create(data, userId);
    res.redirect("/disaster/");
  } catch (error) {
    res.render("disaster/create", {
      error: getErrorMessage(error),
      disaster: data,
    });
  }
});

controller.get("/:id/edit", isAuth, async (req, res) => {
  const disasterId = req.params.id;
  const userId = req.user.id;
  let disaster;

  try {
    disaster = await service.byId(disasterId);
    disaster._id = disasterId;

    if (userId !== disaster.owner.toString()) {
      return res.redirect("/");
    }

    res.render("disaster/edit", { disaster: disaster });
  } catch (error) {
    res.render("disaster/edit", {
      error: getErrorMessage(error),
    });
  }
});

controller.post("/:id/edit", isAuth, async (req, res) => {
  const disasterId = req.params.id;
  const userId = req.user.id;
  let data = req.body;

  try {
    const disaster = await service.byId(disasterId);

    if (userId !== disaster.owner.toString()) {
      return res.redirect("/");
    }

    await service.update(disasterId, data);
    res.redirect(`/disaster/${disasterId}/details`);
  } catch (error) {
    data = { ...data, _id: disasterId };
    res.render("disaster/edit", {
      error: getErrorMessage(error),
      disaster: data,
    });
  }
});

controller.get("/:id/delete", isAuth, async (req, res) => {
  const disasterId = req.params.id;
  const userId = req.user.id;

  try {
    await service.remove(disasterId, userId);
    res.redirect("/disaster/");
  } catch (error) {
    console.error(getErrorMessage(error));
  }
});

export default controller;
