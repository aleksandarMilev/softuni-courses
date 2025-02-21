import { Router } from "express";

import { isAuth } from "../middlewares/auth-middleware.js";
import { getErrorMessage } from "../common/functions.js";
import * as service from "../services/interested-service.js";

const controller = Router();

controller.get("/:id", isAuth, async (req, res) => {
  const disasterId = req.params.id;
  const userId = req.user.id;

  try {
    await service.addInterestedUser(disasterId, userId);
    res.redirect(`/disaster/${disasterId}/details`);
  } catch (error) {
    res.render("disaster/details", {
      error: getErrorMessage(error),
      disaster: null,
    });
  }
});

export default controller;
