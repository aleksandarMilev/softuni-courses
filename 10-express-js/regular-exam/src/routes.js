import { Router } from "express";

import homeController from "./controllers/home-controller.js";
import authController from "./controllers/auth-controller.js";
import disasterController from "./controllers/disaster-controller.js";
import interestedController from "./controllers/interested-controller.js";

const router = Router();

router.use(homeController);
router.use("/auth", authController);
router.use("/disaster", disasterController);
router.use("/interested", interestedController);

export default router;
